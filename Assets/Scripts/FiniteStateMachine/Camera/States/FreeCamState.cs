using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

/// <summary>
/// This state provides the player more control over their Camera
/// This camera state is the more traditional camera style.
/// </summary>
public class FreeCamState : CameraState
{
    Transform target;
    float inputX;
    float inputY;

    public FreeCamState(StateMachine s) : base(s)
    {
        this.stateMachine = s;
        this.target = s.transform.parent.Find("Target").transform;
        this.inputX = 0;
        this.inputY = 0;
    }

    #region State Events

    public override void OnStateEnter()
    {
        ParentCameraToTargetPivot();
        base.OnStateEnter();
    }

    public override void OnStateExit()
    {
        UnParentCameraToTargetPivot();
        base.OnStateExit();
    }

    public override void StateFixedUpdate()
    {
        SetTargetRotation();
        NormalizeDistance();
    }

    public override void StateUpdate() 
    {
        ClampUserInput();
    }

    #endregion

    #region State Logic

    //This function also snaps the targets rotation to "face" the camera
    void ParentCameraToTargetPivot()
    {
        this.target.rotation = Quaternion.LookRotation(cam.transform.position - target.position, Vector3.up);
        this.cam.transform.parent = this.target.transform;
        this.inputX = target.rotation.eulerAngles.y;
        
        //HACK fixes a slight camera snap when entering this state
        this.inputY = target.rotation.eulerAngles.x - 360;
    }

    void UnParentCameraToTargetPivot()
    {
        this.cam.transform.parent = this.target.transform.parent;
    }

    void ClampUserInput()
    {
        this.inputX += cam.InputDir.x * cam.freeCamSpeed;
        this.inputY += cam.InputDir.y * cam.freeCamSpeed;
        inputY = Mathf.Clamp(inputY, -cam.freeCamYClamp, cam.freeCamYClamp);
    }
    void SetTargetRotation()
    {
        this.target.rotation = Quaternion.Euler(
            inputY,
            inputX,
            0);
    }

    void NormalizeDistance()
    {
        Vector3 vec = cam.transform.position - target.position;
        vec = vec.normalized;

        cam.transform.position = target.position + vec * cam.distFromPlayer;
    }
    #endregion
}
