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
        Knockback();

        enemy.Anim.Play("Male Die", 0);

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

    void Knockback()
    {
        Vector3 moveDir = enemy.transform.position - enemy.player.transform.position;
        moveDir.y = 0;
        moveDir = moveDir.normalized;
        moveDir.y = enemy.player.hitCount / 3.0f;

        enemy.Rb.AddForce(moveDir * enemy.knockbackMagnitude * enemy.player.hitCount);
    }
    #endregion
}
