using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraState : State
{
    protected CameraController cam;

    public CameraState(StateMachine s) : base(s)
    {
        this.stateMachine = s;
        this.cam = (CameraController)this.stateMachine;
    }
}
