using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingEnemyState : EnemyState
{
    float animLength;
    float animStart;
    bool isLanding;
    public FallingEnemyState(StateMachine s) : base(s)
    {     
        this.isLanding = false;
    }

    #region State Events
    public sealed override void OnStateEnter()
    {
        enemy.Anim.CrossFade("Male Fall", 0.1f);

        base.OnStateEnter();
    }
    public sealed override void StateFixedUpdate()
    {
        CheckIfEnemyHitGround();
        ExitStateWhenLandAnimationCompletes();
    }

    public sealed override void StateUpdate() { }

    public sealed override void OnStateExit()
    {
        base.OnStateExit();
    }
    #endregion

    #region State Logic

    void CheckIfEnemyHitGround()
    {
        if (enemy.hit.distance < enemy.minFallDistance && !isLanding)
        {
            enemy.Anim.CrossFade("Male Land", 0.1f);
            this.animLength = enemy.Anim.runtimeAnimatorController.animationClips[0].length;
            this.animStart = Time.time;
            this.isLanding = true;
        }
    }

    void ExitStateWhenLandAnimationCompletes()
    {
        if (isLanding && Time.time > animStart + animLength)
        {
            enemy.SetState(new IdleEnemyState(enemy));
        }
    }
    #endregion
}
