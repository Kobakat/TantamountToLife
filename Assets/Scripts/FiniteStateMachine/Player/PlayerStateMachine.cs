﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    //TODO
    //Encapsulate these with assesors

    public Rigidbody rb = null;
    public Camera cam = null;
    public Animator anim = null;
    public Collider weapon = null;
    public CapsuleCollider playerCol = null;

    public PhysicMaterial stopMaterial = null;
    public PhysicMaterial moveMaterial = null;

    public Vector2 inputDir;

    public float speed = 5;
    public float maxSpeed = 3;
    public float turnSpeed = 1000;

    void Start()
    {
        this.SetState(state = new IdleState(this));
        rb = this.GetComponent<Rigidbody>();
        playerCol = this.GetComponent<CapsuleCollider>(); 
    }
    
    void Update() { this.state.StateUpdate(); }

    void FixedUpdate() { this.state.StateFixedUpdate(); }
}
