using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TakeDamageState : PlayerState
{
    InputAction[] actionsToHandle;
    float startTime;
    float animLength;

    public TakeDamageState(StateMachine s) : base(s)
    {
        actionsToHandle = new InputAction[3] { this.player.InputHandler.Standard.Movement, this.player.InputHandler.Standard.Attack, this.player.InputHandler.Standard.Target };
    }

    #region State Events

    public override void StateUpdate()
    {
        ReturnToNormalStateWhenAnimationFinishes();
    }

    public sealed override void StateFixedUpdate() { }


    public sealed override void OnStateEnter()
    {
        player.DisableActions(actionsToHandle);

        SetAnimationInfo();
    }

    public sealed override void OnStateExit()
    {
        player.EnableActions(actionsToHandle);
    }
    #endregion

    #region State Logic

    void SetAnimationInfo()
    {
        player.Anim.CrossFade("Male Damage Light", 0.1f);

        this.startTime = Time.time;
        this.animLength = player.Anim.runtimeAnimatorController.animationClips[0].length;
    }

    void ReturnToNormalStateWhenAnimationFinishes()
    {
        if (Time.time > startTime + animLength)
            player.SetState(new OrbitState(player));
    }
    #endregion
}
