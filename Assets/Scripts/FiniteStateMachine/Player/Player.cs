using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Monobehavior that controls player's state and input (IControllable)
/// </summary>
public class Player : StateMachine, IControllable
{
    #region Properties
    public InputHandler InputHandler { get; set; }
    public Rigidbody Rb { get; protected set; }
    public Camera Cam { get; protected set; }
    public Animator Anim { get; protected set; }
    public CapsuleCollider PlayerCol { get; protected set; }
  
    public Vector2 InputDir { get; protected set; }
    public RaycastHit hit;

    public Collider Weapon;
    public PhysicMaterial StopMaterial;
    public PhysicMaterial MoveMaterial;
    public Shader damageShader;
    public List<Interactable> Interactables { get; set; }

    [SerializeField] Transform RayOrigin = null;
    public List<Material> Mats { get; set; }
    public ParticleSystem Particle { get; set; }
    public AudioSource Audio { get; set; }


    public AudioClip hitOne = null;
    public AudioClip hitTwo = null;
    public AudioClip hitThree = null;
    public AudioClip healthPick = null;

    public float Speed = 3;
    public float MaxSpeed = 5;
    public float TurnSpeed = 1000;
    public float minFallDistance = 1;
    int layerMask;

    public int hitCount { get; set; }
    public bool queuedAtt { get; set; }
    public bool isVulnerable { get; set; }

    public int health = 10;
    public int maxHealth = 10;
    public float invulnerabilityTime = 3;
    public static int gold = 0;

    //How long after a 3 hit combo a player can attack again
    public float comboTimeout = 1;
    #endregion

    #region Unity Event Functions
    void Start()
    {
        //Make sure all components are initialized first
        this.Anim = this.GetComponent<Animator>();
        this.Rb = this.GetComponent<Rigidbody>();
        this.PlayerCol = this.GetComponent<CapsuleCollider>();
        this.Cam = this.transform.parent.GetComponentInChildren<Camera>();
        this.Interactables = new List<Interactable>();
        this.Particle = this.GetComponentInChildren<ParticleSystem>();
        this.Audio = this.GetComponent<AudioSource>();

        //Then state info
        this.SetState(state = new OrbitState(this));
        this.isVulnerable = true;
        this.layerMask = LayerMask.GetMask("Ground");

        GetMaterialsForDamageFlicker();
    }

    void Update()
    {
        InputDir = this.InputHandler.Standard.Movement.ReadValue<Vector2>();

        this.state.StateUpdate();
    }

    void FixedUpdate() 
    {
        this.CheckForFall();
        this.state.StateFixedUpdate(); 
    }

    void OnEnable()
    {
        this.InputHandler.Standard.Attack.performed += OnAttack;
        this.InputHandler.Standard.Movement.performed += OnOrbitStart;
        this.InputHandler.Standard.Movement.canceled += OnOrbitStop;
        this.InputHandler.Standard.Interact.performed += OnInteract;

        this.InputHandler.Enable();
    }

    void OnDisable()
    {
        this.InputHandler.Standard.Attack.performed -= OnAttack;
        this.InputHandler.Standard.Movement.canceled += OnOrbitStart;
        this.InputHandler.Standard.Movement.canceled -= OnOrbitStop;
        this.InputHandler.Standard.Interact.performed -= OnInteract;

        this.InputHandler.Disable();
    }

    void OnTriggerEnter(Collider other)
    {
        InteractionPrompt.Invoke(this.Interactables.Count > 0);

        switch(other.tag)
        {
            case "Enemy Weapon":
                if  (isVulnerable) 
                {
                    this.SetState(new TakeDamageState(this));
                    PlayerDamaged.Invoke();
                }
                break;

            case "Health":
                if(health < maxHealth)
                {
                    health += 2;

                    if (health > 10)
                        health = 10;

                    HealthPickup.Invoke();
                    Audio.PlayOneShot(healthPick);

                    other.gameObject.SetActive(false);
                    
                }
                break;
        }
    }

    void OnTriggerExit()
    {
        InteractionPrompt.Invoke(this.Interactables.Count > 0);
    }

    #endregion

    #region Player Input

    void OnAttack(InputAction.CallbackContext context) 
    { 
        if(this.hitCount == 0)
        {
            this.SetState(new AttackState(this));
        }

        else
        {
            this.queuedAtt = true;
        }
    }
    void OnOrbitStart(InputAction.CallbackContext context) { this.Anim.CrossFade("Male_Sword_Walk", 0.1f); }
    void OnOrbitStop(InputAction.CallbackContext context) { this.Anim.CrossFade("Male Sword Stance", 0.1f); }

    void OnInteract(InputAction.CallbackContext context)
    {
        List<Interactable> interactablesToDispose = new List<Interactable>();

        foreach(Interactable interactable in this.Interactables)
        {
            if (interactable)
            {
                interactable.InteractionEvent();
                interactablesToDispose.Add(interactable);
            }
        }
        
        foreach(Interactable interactable in interactablesToDispose)
        {
            this.Interactables.Remove(interactable);
        }

        interactablesToDispose.Clear();

        InteractionPrompt.Invoke(this.Interactables.Count > 0);
        GoldPickup.Invoke();
    }

    #endregion

    #region IControllable
    public void EnableActions(InputAction[] Actions)
    {
        foreach(InputAction action in Actions)
        {
            if(action != null)
                action.Enable();
        }
    }

    public void DisableActions(InputAction[] Actions)
    {
        foreach (InputAction action in Actions)
        {
            if (action != null)
                action.Disable();
        }
    }
    #endregion IControllable

    #region Events

    public void EnableWeaponCollider()
    {
        Weapon.enabled = true;
    }

    public void DisableWeaponCollider()
    {
        Weapon.enabled = false;
    }

    public static event Action PlayerDamaged;
    public static event Action HealthPickup;
    public static event Action GoldPickup;
    public static event Action<bool> InteractionPrompt;

    #endregion

    /// <summary>
    /// Cast a ray straight down until it hits terrain.
    /// If that distance is too large, the player begins to fall
    /// </summary>
    void CheckForFall()
    {
        //this.transform.rotation = Quaternion.Euler(0, 0, 0);
        if(Physics.Raycast(RayOrigin.position, Vector3.down, out hit, Mathf.Infinity, layerMask))
        {
            if (hit.distance > minFallDistance)
            {
                
                this.SetState(new FallingState(this));
            }
        }
    }

    void GetMaterialsForDamageFlicker()
    {
        SkinnedMeshRenderer[] renderers = transform.parent.GetComponentsInChildren<SkinnedMeshRenderer>();
        this.Mats = new List<Material>();
        foreach (SkinnedMeshRenderer renderer in renderers)
        {
            for(int i = 0; i < renderer.materials.Length; i++)
                this.Mats.Add(renderer.materials[i]);
        }
    }

    public IEnumerator EnableAttackAfterDelay(float lockoutTime)
    {
        yield return new WaitForSeconds(lockoutTime);

        this.InputHandler.Standard.Attack.Enable();
    }
}
