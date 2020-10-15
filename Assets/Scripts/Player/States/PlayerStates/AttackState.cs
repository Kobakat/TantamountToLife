using UnityEditorInternal;
using UnityEngine;

public class AttackState : State
{
    float startTime;
    float animLength;

    public AttackState(Player User) : base(User)
    {
        this.user = User;
        this.startTime = Time.time;
        
        
        //Using a magic number until I do an animator overhaul
        this.animLength = 1; //user.anim.GetCurrentAnimatorStateInfo(0).length;
    }

    public override void StateUpdate()
    {  
        if (Time.time > startTime + animLength)
        {
            user.SetState(new IdleState(user));
        }
    }

    public sealed override void StateFixedUpdate() { }


    public sealed override void OnStateEnter()
    {

        //Turn sword trigger on
        user.weapon.enabled = true;

        user.anim.Play("MaleAttack");
        
        base.OnStateEnter();
    }

    public sealed override void OnStateExit()
    {
        user.weapon.enabled = false;

        base.OnStateExit();
    }
}
