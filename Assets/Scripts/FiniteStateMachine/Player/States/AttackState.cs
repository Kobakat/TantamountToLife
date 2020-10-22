using UnityEditorInternal;
using UnityEngine;

public class AttackState : PlayerState
{
    float startTime;
    float animLength;

    public AttackState(StateMachine s) : base(s)
    {
        this.stateMachine = s;
        this.startTime = Time.time;
    }

    public override void StateUpdate()
    {  
        if (Time.time > startTime + animLength)
        {
            player.SetState(new IdleState(player));
        }
    }

    public sealed override void StateFixedUpdate() { }


    public sealed override void OnStateEnter()
    {
        player.anim.CrossFade("MaleAttack", 0.05f);

        this.startTime = Time.time;
        this.animLength = player.anim.runtimeAnimatorController.animationClips[0].length;

        player.weapon.enabled = true;
        
        base.OnStateEnter();
    }

    public sealed override void OnStateExit()
    {
        player.weapon.enabled = false;

        base.OnStateExit();
    }
}
