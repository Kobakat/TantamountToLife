using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleEnemyState : EnemyState
{
    public IdleEnemyState(StateMachine s) : base(s)
    {
        
    }

    public override void OnStateEnter()
    {
        enemy.Anim.CrossFade("Male Idle", 0.2f);
        base.OnStateEnter();
    }

    public override void OnStateExit() { base.OnStateExit();  }


    public override void StateFixedUpdate() { }

    public override void StateUpdate() { }

}
