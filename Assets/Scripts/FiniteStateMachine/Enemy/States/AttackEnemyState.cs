using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemyState : EnemyState
{
    public bool hasStruck;

    float animLength;
    float startTime;
    int random;
    bool isAttacking;
    
    public AttackEnemyState(StateMachine s) : base(s)
    {
        this.hasStruck = false;

        this.animLength = 0;
        this.startTime = 0;
        this.random = 0;
        this.isAttacking = false;
    }
    
    #region State Events
    public override void OnStateEnter()
    {       
        this.startTime = Time.time;
        this.random = Random.Range(1, 4);
        this.animLength = enemy.Anim.runtimeAnimatorController.animationClips[0].length / 1.5f;

        enemy.Anim.CrossFade("Male Sword Stance", 0.2f);

        base.OnStateEnter();
    }

    public override void OnStateExit() 
    {       
        base.OnStateExit(); 
    }


    public override void StateFixedUpdate() { }

    public override void StateUpdate() 
    {
        AttackAfterDelay();
        PlayUntilAnimationIsCompleted();
    }

    #endregion

    #region State Logic

    void PlayUntilAnimationIsCompleted()
    {
        if(Time.time > this.startTime + this.animLength && isAttacking)
        {
            enemy.SetState(new AttackEnemyState(enemy));
        }
    }

    void AttackAfterDelay()
    {
        if(Time.time > this.startTime + enemy.attackDelay && !isAttacking)
        {
            isAttacking = true;

            switch (random)
            {
                case 1:
                    enemy.Anim.CrossFade("MaleAttack", 0.1f);
                    break;
                case 2:
                    enemy.Anim.CrossFade("Male Attack 2", 0.1f);
                    break;
                case 3:
                    enemy.Anim.CrossFade("Male Attack 3", 0.1f);
                    break;
            }

            this.startTime = Time.time;
        }
            
            
    }

    #endregion
}
