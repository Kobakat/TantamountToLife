using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TargetState : PlayerState
{
    Vector3 forward, right;

    InputAction[] actions;
    public TargetState(StateMachine s) : base(s)
    {
        this.stateMachine = s;
        this.forward = Vector3.zero;
        this.right = Vector3.zero;

        actions = new InputAction[1] { player.InputHandler.Standard.Attack };
    }


    public sealed override void StateUpdate() { }

    //TODO
    //Disable normal movement when in this state
    public sealed override void StateFixedUpdate() 
    {
        Vector3 forward = player.Cam.transform.forward;
        Vector3 right = player.Cam.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        player.Rb.velocity = Vector3.ClampMagnitude((forward * player.InputDir.y) + (right * player.InputDir.x), 1.0f) * player.Speed;
    }
    public sealed override void OnStateEnter()
    {
        player.Anim.CrossFade("Male Sword Block", 0.15f);
        player.DisableActions(actions);
        base.OnStateEnter();
    }
    public sealed override void OnStateExit() 
    {
        player.EnableActions(actions);
        base.OnStateExit(); 
    }

}
