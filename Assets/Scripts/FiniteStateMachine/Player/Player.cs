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

    public Collider Weapon;
    public PhysicMaterial StopMaterial;
    public PhysicMaterial MoveMaterial;

    public float Speed = 3;
    public float MaxSpeed = 5;
    public float TurnSpeed = 1000;

    public int hitCount = 0;
    public bool queuedAtt = false;
    #endregion

    #region Unity Event Functions
    void Start()
    {
        //Make sure all components are initialized first
        this.Anim = this.GetComponent<Animator>();
        this.Rb = this.GetComponent<Rigidbody>();
        this.PlayerCol = this.GetComponent<CapsuleCollider>();
        this.Cam = this.transform.parent.GetComponentInChildren<Camera>();
        //Then set the state
        this.SetState(state = new OrbitState(this));
    }

    void Update()
    {
        InputDir = this.InputHandler.Standard.Movement.ReadValue<Vector2>();

        this.state.StateUpdate();
    }

    void FixedUpdate() { this.state.StateFixedUpdate(); }

    private void OnEnable()
    {
        this.InputHandler.Standard.Attack.performed += OnAttack;
        this.InputHandler.Standard.Movement.performed += OnOrbitStart;
        this.InputHandler.Standard.Movement.canceled += OnOrbitStop;
        this.InputHandler.Standard.Target.performed += OnTargetStart;
        this.InputHandler.Standard.Target.canceled += OnTargetStop;

        this.InputHandler.Enable();
    }

    private void OnDisable()
    {
        this.InputHandler.Standard.Attack.performed -= OnAttack;
        this.InputHandler.Standard.Movement.canceled += OnOrbitStart;
        this.InputHandler.Standard.Movement.canceled -= OnOrbitStop;
        this.InputHandler.Standard.Target.performed -= OnTargetStart;
        this.InputHandler.Standard.Target.canceled -= OnTargetStop;

        this.InputHandler.Disable();
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
    void OnTargetStart(InputAction.CallbackContext context) { this.SetState(new TargetState(this)); }
    void OnTargetStop(InputAction.CallbackContext context) { this.SetState(new OrbitState(this)); }
    void OnOrbitStart(InputAction.CallbackContext context) { this.Anim.CrossFade("Male_Sword_Walk", 0.2f); }
    void OnOrbitStop(InputAction.CallbackContext context) { this.Anim.CrossFade("Male Sword Stance", 0.2f); }

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
}
