using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected State state;

    public State State
    {
        get { return state; }
        protected set { this.state = value; }
    }

    public virtual void SetState(State newState)
    {
        state?.OnStateExit();

        state = newState;

        state?.OnStateEnter();
    }
}
