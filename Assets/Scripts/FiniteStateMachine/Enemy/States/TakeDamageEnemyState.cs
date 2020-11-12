﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageEnemyState : EnemyState
{
    float startTime;
    float animLength;

    public TakeDamageEnemyState(StateMachine s) : base(s)
    {

    }

    #region State Events

    public override void StateUpdate()
    {
        ReturnToNormalStateWhenAnimationFinishes();
    }

    public sealed override void StateFixedUpdate() { }


    public sealed override void OnStateEnter()
    {
        enemy.health -= 2;

        SetAnimationInfo();

        if (enemy.health <= 0)
        {
            enemy.SetState(new DyingEnemyState(enemy));
        }

    }

    public sealed override void OnStateExit()
    {

    }
    #endregion

    #region State Logic

    void SetAnimationInfo()
    {
        this.startTime = Time.time;

        enemy.Anim.CrossFade("Male Damage Light", 0);

        this.animLength = enemy.Anim.runtimeAnimatorController.animationClips[0].length / 2;

    }

    void ReturnToNormalStateWhenAnimationFinishes()
    {
        if (Time.time > startTime + animLength)
            enemy.SetState(new AttackEnemyState(enemy));
    }

    #endregion
}