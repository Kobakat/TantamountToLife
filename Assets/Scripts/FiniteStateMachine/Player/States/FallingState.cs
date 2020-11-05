using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FallingState : PlayerState
{
    InputAction[] actionsToHandle;
    float animLength;
    float animStart;
    bool isLanding;
    public FallingState(StateMachine s) : base(s)
    {
        this.actionsToHandle = new InputAction[3] { player.InputHandler.Standard.Movement, player.InputHandler.Standard.Attack, player.InputHandler.Standard.Target };
        this.isLanding = false;
    }
    #region State Events
    public sealed override void OnStateEnter()
    {
        player.DisableActions(actionsToHandle);
        player.Anim.CrossFade("Male Fall", 0.1f);

        base.OnStateEnter();
    }
    public sealed override void StateFixedUpdate()
    {
        if(player.hit.distance < player.minFallDistance && !isLanding)
        {
            player.Anim.CrossFade("Male Land", 0.1f);
            this.animLength = player.Anim.runtimeAnimatorController.animationClips[0].length;
            this.animStart = Time.time;
            this.isLanding = true;
        }

        if(isLanding && Time.time > animStart + animLength)
        {
            player.SetState(new OrbitState(player));
        }
    }

    public sealed override void StateUpdate() { }
    
    public sealed override void OnStateExit()
    {
        player.EnableActions(actionsToHandle);
        base.OnStateExit(); 
    }
    #endregion

    #region State Logic
    #endregion
}
