using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackState : PlayerState
{
    float startTime;
    float animLength;

    

    InputAction[] actionsToHandle;


    
    public AttackState(StateMachine s) : base(s)
    {
        this.stateMachine = s;
        
        //Decide what forms of input get disabled during this state
        actionsToHandle = new InputAction[2] { this.player.InputHandler.Standard.Movement, null };
        
    }

    #region State Events

    public override void StateUpdate()
    {
        PlayAttackAnimationUntilCompletion();
        
    }

    public sealed override void StateFixedUpdate() { }


    public sealed override void OnStateEnter()
    {
        player.DisableActions(actionsToHandle);
        player.hitCount = 1;

        PlayAttackAnimation();

        PlayerWeaponColliderEnabled(true); 

        base.OnStateEnter();
    }

    public sealed override void OnStateExit()
    {
        PlayerWeaponColliderEnabled(false);

        player.EnableActions(actionsToHandle);
        player.hitCount = 0;

    }

    #endregion

    #region State Logic
    void PlayerWeaponColliderEnabled(bool t)
    {
        player.Weapon.enabled = t;
    }

    void PlayAttackAnimation()
    {
        switch(player.hitCount)
        {
            case 1:
                player.Anim.CrossFade("MaleAttack", 0.05f);
                break;
            case 2:
                player.Anim.CrossFade("Male Attack 2", 0.05f);
                break;
            case 3:
                player.Anim.CrossFade("Male Attack 3", 0.05f);
                break;
        }
            
        this.startTime = Time.time;

        //HACK, fix hard coded speed animation
        //While all attack animations in this package are the same duration
        //This should still use a variable instead of a magic 1.5
        this.animLength = player.Anim.runtimeAnimatorController.animationClips[0].length / 1.5f;
    }

    void PlayAttackAnimationUntilCompletion()
    {
        if (Time.time > startTime + animLength)
            HandleChainAttacks();

        DisableAttacksAfterMaxHits();
    }

    void HandleChainAttacks()
    {
        if (player.queuedAtt && player.hitCount < 4)
        {
            player.queuedAtt = false;
            player.hitCount++;
            PlayAttackAnimation();
        }

        else
            player.SetState(new OrbitState(player));
    }

    void DisableAttacksAfterMaxHits()
    {
        if (player.hitCount >= 3)
        {
            this.actionsToHandle[1] = player.InputHandler.Standard.Attack;
            player.DisableActions(this.actionsToHandle);
        }
    }
    #endregion
}
