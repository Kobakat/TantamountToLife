using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingEnemyState : EnemyState
{
    public DyingEnemyState(StateMachine s) : base(s)
    {

    }

    #region State Events

    public override void OnStateEnter()
    {
        enemy.Anim.CrossFade("Male Die", 0.2f);

        Disable();

        base.OnStateEnter();
    }

    public override void OnStateExit() { base.OnStateExit(); }

    public override void StateFixedUpdate() { }

    public override void StateUpdate() { }

    #endregion

    #region State Logic
    void Disable()
    {
        enemy.gameObject.layer = 9;
        enemy.enabled = false;
        enemy.transform.parent.Find("RangeTriggers").gameObject.SetActive(false);
    }
    #endregion
}
