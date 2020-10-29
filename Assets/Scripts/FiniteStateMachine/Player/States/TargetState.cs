using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// In this state, the player faces one direction and move relative to input.
/// Useful for reorienting the camera behind the player.
/// </summary>
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

    #region State Event Functions
    public sealed override void StateUpdate() { }

    
    public sealed override void StateFixedUpdate() 
    {
        MovePlayer();
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

    #endregion

    #region State Logic
    void MovePlayer()
    {
        forward = player.Cam.transform.forward;
        right = player.Cam.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        player.Rb.velocity = Vector3.ClampMagnitude((forward * player.InputDir.y) + (right * player.InputDir.x), 1.0f) * player.Speed;
    }
    #endregion

}
