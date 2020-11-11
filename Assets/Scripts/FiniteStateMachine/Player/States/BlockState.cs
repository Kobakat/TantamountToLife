using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BlockState : TargetState
{
    public BlockState(StateMachine s) : base(s)
    {
        this.stateMachine = s;
    }

    public sealed override void OnStateEnter()
    {
        player.Anim.CrossFade("Male Sword Block", 0.2f);
        base.OnStateEnter();
    }

    public sealed override void OnStateExit()
    {
        base.OnStateExit();
    }

    public sealed override void StateUpdate()
    {
        base.StateUpdate();
    }

    public sealed override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
    }
}
