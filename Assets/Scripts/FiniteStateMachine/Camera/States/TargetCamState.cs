using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Snaps the camera behind the player and holds it steady
/// </summary>

public class TargetCamState : CameraState
{
    Vector3 targetPos, center, newXZ;

    float timer;
    float snapSpeed;

    InputAction[] actionsToHandle;

    public TargetCamState(StateMachine s) : base(s) 
    {
        this.snapSpeed = 7;
        this.actionsToHandle = new InputAction[2] { cam.InputHandler.Standard.FirstPersonCam, cam.InputHandler.Standard.FreeCam };
    }

    #region State Events
    public override void StateFixedUpdate()
    {
        WrapCameraBehindPlayer();
    }

    public override void StateUpdate() { }
    public override void OnStateEnter() 
    {
        cam.DisableActions(actionsToHandle);
        base.OnStateEnter(); 
    }
    public override void OnStateExit() 
    {
        cam.EnableActions(actionsToHandle);
        base.OnStateExit(); 
    }
    #endregion

    #region State Logic

    void WrapCameraBehindPlayer()
    {
        timer += Time.deltaTime;

        targetPos = cam.target.position + (cam.transform.parent.Find("Character").forward * -1).normalized * cam.distFromPlayer + new Vector3(0, cam.height, 0);
        center = cam.target.position;

        newXZ = Vector3.Slerp(cam.transform.position - center, targetPos - center, timer * snapSpeed) + center;

        cam.transform.position = new Vector3(newXZ.x, cam.transform.position.y, newXZ.z);

        cam.transform.position = new Vector3(cam.transform.position.x, Mathf.Lerp(cam.transform.position.y, targetPos.y, timer), cam.transform.position.z);

        cam.transform.LookAt(cam.target);

        if(Vector3.Distance(targetPos, cam.transform.position) <= 0.05f)
        {
            cam.SetState(new OrbitCamState(cam));
        }
    }
    #endregion

}
