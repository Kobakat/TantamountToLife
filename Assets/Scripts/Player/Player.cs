using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    //TODO
    //Encapsulate these with assesors

    public Rigidbody rb = null;
    public Camera cam = null;
    public Animator anim = null;
    public Collider weapon = null;

    public Vector2 inputDir;

    public float speed = 5;
    public float maxSpeed = 3;
    public float turnSpeed = 1000;

    void Start()
    {
        SetState(state = new IdleState(this));
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        this.state.StateUpdate();
    }

    void FixedUpdate()
    {       
        this.state.StateFixedUpdate();
    }
    
}
