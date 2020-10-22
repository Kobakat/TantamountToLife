using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraState : State
{
    protected CameraStateMachine cam;

    public CameraState(StateMachine s) : base(s)
    {
        this.stateMachine = s;
        this.cam = (CameraStateMachine)this.stateMachine;
    }
}
