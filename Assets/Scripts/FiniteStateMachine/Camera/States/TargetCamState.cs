using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCamState : CameraState
{
    Vector3 targetPos, center, newXZ;

    float timer;
    public TargetCamState(StateMachine s) : base(s) { }


    public override void StateFixedUpdate()
    {
        timer += Time.deltaTime;

        if(Vector3.Distance(cam.transform.position, targetPos) > 0.01)
        {
            newXZ = Vector3.Slerp(cam.transform.position, targetPos, timer);
            cam.transform.position = new Vector3(newXZ.x, cam.transform.position.y, newXZ.z);
        }

        else
        {
            targetPos = cam.target.position + (cam.target.forward * -1).normalized * cam.distFromPlayer;
            targetPos.y += cam.height;
            cam.transform.position = targetPos;
        }
              
        cam.transform.LookAt(cam.target);
    }

    public override void StateUpdate() { }
    public override void OnStateEnter() 
    {
        targetPos = cam.target.position + (cam.target.forward * -1).normalized * cam.distFromPlayer;
        targetPos.y += cam.height;
        center = targetPos + (targetPos + cam.transform.position) / 2;
        
        base.OnStateEnter(); 
    }
    public override void OnStateExit() { base.OnStateExit(); }

}
