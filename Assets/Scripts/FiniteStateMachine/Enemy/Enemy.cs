using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : StateMachine
{
    public Player player;
    public Rigidbody Rb { get; protected set; }
    public Animator Anim { get; protected set; }
    public Collider EnemyCol { get; protected set; }
    
    public Collider Weapon;
    public PhysicMaterial StopMaterial;
    public PhysicMaterial MoveMaterial;

    public int health = 10;
    
    public float Speed = 3;
    public float TurnSpeed = 1000;
    public float minFallDistance = 1;

    public float attackDelay = 1.0f;

    #region Unity Event Functions
    void Start()
    {
        //Make sure all components are initialized first
        this.Anim = this.GetComponent<Animator>();
        this.Rb = this.GetComponent<Rigidbody>();
        this.EnemyCol = this.GetComponent<CapsuleCollider>();

        //Then set the state
        this.SetState(state = new IdleEnemyState(this));
    }

    void Update()
    {
        this.state.StateUpdate();
    }

    void FixedUpdate()
    {
        this.state.StateFixedUpdate();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            this.SetState(new DyingEnemyState(this));
        }

        if(other.CompareTag("Player"))
        {
            
        }
    }

    #endregion

    #region Delegates

    #endregion

}
