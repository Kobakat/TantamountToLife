using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitState : PlayerState
{
    Vector3 velocity, forward, look;

    Quaternion destRot;
   
    public OrbitState(StateMachine s) : base(s)
    {
        this.stateMachine = s;
        this.velocity = Vector3.zero;
    }

    public sealed override void StateUpdate()
    {               
        Rotate();
    }

    public override void StateFixedUpdate() 
    {
        velocity.z = Mathf.Clamp(player.inputDir.sqrMagnitude, 0.0f, 1.0f) * player.speed;
        player.rb.velocity = player.transform.rotation * new Vector3(0.0f, 0.0f, velocity.z) + new Vector3(0.0f, velocity.y, 0.0f);
    }

    public sealed override void OnStateEnter()
    {
        player.anim.Play("Male_Sword_Walk");
        
        base.OnStateEnter();
    }

    public sealed override void OnStateExit()
    {        
        base.OnStateExit();
    }

    //Rotates the player relative to camera
    void Rotate()
    {
        forward = player.cam.transform.forward;
        forward.y = 0;
        forward = forward.normalized;

        look = Quaternion.LookRotation(forward) * new Vector3(player.inputDir.x, 0.0f, player.inputDir.y);

        if (look != Vector3.zero)
        {
            destRot = Quaternion.LookRotation(look);
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, destRot, player.turnSpeed * Time.deltaTime);
        }
    }
}
