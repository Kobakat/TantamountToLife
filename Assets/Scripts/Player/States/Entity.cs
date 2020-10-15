using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public abstract class Entity : MonoBehaviour
{
    protected State state;

    public State State
    {
        get { return state; }
        set { this.state = value; }
    }

    public virtual void SetState(State newState)
    {
        state?.OnStateExit();

        state = newState;

        state?.OnStateEnter();
    }
}
