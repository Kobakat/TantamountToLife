using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamState : CameraState
{
    Vector3 adjust, targetPos;

    public OrbitCamState(StateMachine s) : base(s)
    {
        this.adjust = Vector2.zero;
        this.targetPos = Vector2.zero;
    }

    public sealed override void StateFixedUpdate()
    {
        adjust = new Vector3(cam.transform.position.x, cam.target.position.y + cam.height, cam.transform.position.z);
        cam.transform.position = adjust;

        targetPos = cam.target.position + (cam.transform.position - cam.target.position).normalized * cam.distFromPlayer;
        cam.transform.position = targetPos;

        cam.transform.LookAt(cam.target);
    }

    public sealed override void StateUpdate() { }
    public sealed override void OnStateEnter() { base.OnStateEnter(); }
    public sealed override void OnStateExit() { base.OnStateExit(); }

}
