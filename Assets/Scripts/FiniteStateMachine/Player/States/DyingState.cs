using System;

public class DyingState : PlayerState
{
    public static event Action PlayerDeath;
    public DyingState(StateMachine s) : base(s)
    {

    }

    #region State Events

    public override void OnStateEnter()
    {
        player.Anim.CrossFade("Male Die", 0.2f);
        PlayerDeath.Invoke();
        DisablePlayer();

    }

    public override void OnStateExit() { base.OnStateExit(); }

    public override void StateFixedUpdate() { }

    public override void StateUpdate() { }

    #endregion

    #region State Logic
    void DisablePlayer()
    {      
        player.gameObject.layer = 9;
        player.enabled = false;    
    }

    #endregion
}
