using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitState : State
{
    Vector3 velocity;
    public OrbitState(Player User) : base((Player)User)
    {
        this.user = User;
        this.velocity = Vector3.zero;
    }

    public sealed override void StateUpdate()
    {               
        Rotate();
    }

    public override void StateFixedUpdate() 
    {
        velocity.z = Mathf.Clamp(user.inputDir.sqrMagnitude, 0.0f, 1.0f) * user.speed;
        user.rb.velocity = user.transform.rotation * new Vector3(0.0f, 0.0f, velocity.z) + new Vector3(0.0f, velocity.y, 0.0f);
    }

    public sealed override void OnStateEnter()
    {
        user.anim.Play("Male_Sword_Walk");
        
        base.OnStateEnter();
    }

    public sealed override void OnStateExit()
    {        
        base.OnStateExit();
    }

    //Rotates the player relative to camera
    void Rotate()
    {
        Vector3 forward = user.cam.transform.forward;
        forward.y = 0;
        forward = forward.normalized;

        Vector3 look = Quaternion.LookRotation(forward) * new Vector3(user.inputDir.x, 0.0f, user.inputDir.y);

        if (look != Vector3.zero)
        {
            Quaternion destRot = Quaternion.LookRotation(look);
            user.transform.rotation = Quaternion.RotateTowards(user.transform.rotation, destRot, user.turnSpeed * Time.deltaTime);
        }
    }


}
