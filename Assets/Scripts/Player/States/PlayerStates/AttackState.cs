using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{

    public AttackState(Player User) : base(User)
    {
        this.user = User;
        
    }

    public override void StateUpdate()
    {
        if (user.anim.GetCurrentAnimatorStateInfo(0).IsName("Male Attack1"))
        {
            return;
        }
        user.SetState(new IdleState(user));
    }

    public sealed override void StateFixedUpdate() { }


    public sealed override void OnStateEnter()
    {
        //Turn sword trigger on
        user.anim.Play("Male Attack 1");
        base.OnStateEnter();
    }

    public sealed override void OnStateExit()
    {
        //Turn sword trigger off
        base.OnStateExit();
    }
}
