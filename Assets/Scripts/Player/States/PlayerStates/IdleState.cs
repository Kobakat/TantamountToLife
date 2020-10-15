using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public IdleState(Player User) : base(User)
    {
        this.user = User;
    }

    //Nothing really happens in the idle state

    public sealed override void StateUpdate() { }
    public sealed override void StateFixedUpdate() { }
    public sealed override void OnStateEnter() 
    {
        user.anim.Play("Male Sword Stance");
        base.OnStateEnter(); 
    }
    public sealed override void OnStateExit() { base.OnStateExit(); }






}
