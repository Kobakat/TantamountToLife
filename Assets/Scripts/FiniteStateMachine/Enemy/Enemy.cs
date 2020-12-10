using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : StateMachine
{
    #region Properties
    public Player player { get; protected set; }
    public Rigidbody Rb { get; protected set; }
    public Animator Anim { get; protected set; }
    public Collider EnemyCol { get; protected set; }
    
    public Collider Weapon;
    public PhysicMaterial StopMaterial;
    public PhysicMaterial MoveMaterial;
    public Shader damageShader;

    [SerializeField] Transform RayOrigin = null;
    public List<Material> Mats { get; set; }

    public RaycastHit hit;

    public int health = 10;
    
    public float Speed = 3;
    public float TurnSpeed = 1000;
    public float minFallDistance = 1;
    int layerMask;

    public float attackDelay = 1.0f;
    public float knockbackMagnitude = 15000;

    #endregion

    #region Unity Event Functions
    void Start()
    {
        //Make sure all components are initialized first
        this.player = (Player)FindObjectOfType(typeof(Player));
        
        this.Anim = this.GetComponent<Animator>();
        this.Rb = this.GetComponent<Rigidbody>();
        this.EnemyCol = this.GetComponent<CapsuleCollider>();

        //Then set the state
        this.SetState(state = new IdleEnemyState(this));

        this.layerMask = LayerMask.GetMask("Ground");

        GetMaterialsForDamageFlicker();
    }

    void Update()
    {
        this.state.StateUpdate();
    }

    void FixedUpdate()
    {
        CheckForFall();
        this.state.StateFixedUpdate();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon") && this.state.GetType() != typeof(DyingEnemyState))
        {
            this.SetState(new TakeDamageEnemyState(this));
        }
    }

    public void EnableWeaponCollider()
    {
        Weapon.enabled = true;
    }

    public void DisableWeaponCollider()
    {
        Weapon.enabled = false;
    }

    #endregion

    void CheckForFall()
    {
        if (Physics.Raycast(RayOrigin.position, Vector3.down, out hit, Mathf.Infinity, layerMask))
        {
            if (hit.distance > minFallDistance)
            {
                this.SetState(new FallingEnemyState(this));
            }
        }
    }

    void GetMaterialsForDamageFlicker()
    {
        SkinnedMeshRenderer[] renderers = transform.parent.GetComponentsInChildren<SkinnedMeshRenderer>();
        this.Mats = new List<Material>();
        foreach (SkinnedMeshRenderer renderer in renderers)
        {
            for (int i = 0; i < renderer.materials.Length; i++)
                this.Mats.Add(renderer.materials[i]);
        }
    }

}
