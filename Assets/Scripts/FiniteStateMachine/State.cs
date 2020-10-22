using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected StateMachine stateMachine;

    public abstract void StateUpdate();
    public abstract void StateFixedUpdate();
    public virtual void OnStateExit() { }
    public virtual void OnStateEnter() { }


    //Temporary hack while i figure out how to cast to a base constructor..
    public State(StateMachine s)
    {
        this.stateMachine = s;
    }
        
}
