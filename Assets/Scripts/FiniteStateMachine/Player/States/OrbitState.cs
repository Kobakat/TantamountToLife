using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Standard movement state for the player character.
/// The character "Orbits" around the camera with relative input movement
/// </summary>

public class OrbitState : PlayerState
{
    Vector3 velocity, forward, look;
    Quaternion destRot;

    public OrbitState(StateMachine s) : base(s)
    {
        this.stateMachine = s;
        this.velocity = Vector3.zero;
    }

    #region State Events
    public sealed override void StateUpdate()
    {               
        Rotate();
    }

    public override void StateFixedUpdate() 
    {
        MovePlayer();
    }

    public sealed override void OnStateEnter()
    {
        player.Anim.CrossFade("Male Sword Stance", .2f);
        player.PlayerCol.material = player.MoveMaterial;
        
        base.OnStateEnter();
    }

    public sealed override void OnStateExit()
    {
        player.PlayerCol.material = player.StopMaterial;
        base.OnStateExit();
    }

    #endregion


    #region State Logic

    void MovePlayer()
    {
        velocity.z = Mathf.Clamp(player.InputDir.sqrMagnitude, 0.0f, 1.0f) * player.Speed;
        player.Rb.velocity = player.transform.rotation * new Vector3(0.0f, 0.0f, velocity.z) + new Vector3(0.0f, player.Rb.velocity.y, 0.0f);
    }

    void Rotate()
    {
        forward = player.Cam.transform.forward;
        forward.y = 0;
        forward = forward.normalized;

        look = Quaternion.LookRotation(forward) * new Vector3(player.InputDir.x, 0.0f, player.InputDir.y);

        if (look != Vector3.zero)
        {
            destRot = Quaternion.LookRotation(look);
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, destRot, player.TurnSpeed * Time.deltaTime);
        }
    }

    #endregion
}
