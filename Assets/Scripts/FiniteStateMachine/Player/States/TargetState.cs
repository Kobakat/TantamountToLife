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

    public TargetState(StateMachine s) : base(s)
    {
        this.stateMachine = s;
        this.forward = Vector3.zero;
        this.right = Vector3.zero;
    }

    #region State Event Functions
    public override void StateUpdate() { }

    
    public override void StateFixedUpdate() 
    {
        MovePlayer();
    }
    public override void OnStateEnter()
    {
        base.OnStateEnter();
    }

    
    public override void OnStateExit() 
    {
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
