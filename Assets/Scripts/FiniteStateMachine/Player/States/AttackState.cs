using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Attacking state. Player enters this state when they press the attack button.
/// If they press the attack button again at anytime, they will Queue for another attack.
/// The player can strike three times to "chain" hits.
/// </summary>
public class AttackState : PlayerState
{
    #region Properties
    float startTime;
    float animLength;
    #endregion

    InputAction[] actionsToHandle;
   
    public AttackState(StateMachine s) : base(s)
    {
        this.stateMachine = s;
        
        //Decide what forms of input get disabled during this state
        actionsToHandle = new InputAction[1] { this.player.InputHandler.Standard.Movement };
        
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

        base.OnStateEnter();
    }

    public sealed override void OnStateExit()
    {
        
        player.hitCount = 0;
    }

    #endregion

    #region State Logic

    void PlayAttackAnimation()
    {
        switch (player.hitCount)
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
            player.EnableActions(actionsToHandle);
            this.actionsToHandle[0] = player.InputHandler.Standard.Attack;
            player.DisableActions(this.actionsToHandle);

            player.StartCoroutine(player.EnableAttackAfterDelay(player.comboTimeout));
        }
    }

    

    
    #endregion
}
