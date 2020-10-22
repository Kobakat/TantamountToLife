using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerState
{
    public IdleState(StateMachine s) : base(s)
    {
        this.stateMachine = s;
    }

    //Nothing really happens in the idle state

    public sealed override void StateUpdate() { }
    public sealed override void StateFixedUpdate() { }
    public sealed override void OnStateEnter() 
    {
        player.anim.CrossFade("Male Sword Stance", 1);
        base.OnStateEnter(); 
    }
    public sealed override void OnStateExit() { base.OnStateExit(); }






}
