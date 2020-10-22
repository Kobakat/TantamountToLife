using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetState : PlayerState
{
    Vector3 forward, right;

    float targetSpeed;
    public TargetState(StateMachine s) : base(s)
    {
        this.stateMachine = s;
        this.forward = Vector3.zero;
        this.right = Vector3.zero;
        this.targetSpeed = 3.0f;
    }


    public sealed override void StateUpdate() { }

    //TODO
    //Disable normal movement when in this state
    public sealed override void StateFixedUpdate() 
    {
        Vector3 forward = player.cam.transform.forward;
        Vector3 right = player.cam.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        Vector3 targetVel = Vector3.ClampMagnitude((forward * player.inputDir.y) + (right * player.inputDir.y), 1.0f) * targetSpeed;
        player.rb.velocity = targetVel;
    }
    public sealed override void OnStateEnter()
    {
        player.anim.CrossFade("Male Sword Block", 0.15f);
        base.OnStateEnter();
    }
    public sealed override void OnStateExit() { base.OnStateExit(); }

}
