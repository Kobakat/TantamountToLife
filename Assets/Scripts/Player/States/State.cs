using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected Player user;

    public abstract void StateUpdate();
    public abstract void StateFixedUpdate();
    public virtual void OnStateExit() { }
    public virtual void OnStateEnter() { }


    //Temporary hack while i figure out how to cast to a base constructor..
    public State(Player User)
    {
        this.user = User;
    }
        
}
