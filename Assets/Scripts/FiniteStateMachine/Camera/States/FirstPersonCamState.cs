using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonCamState : CameraState
{
    Transform player;

    Vector3 targetPos;
    Vector3 offset;

    float snapTime;
    float startTime;
    float frac;

    float inputX;
    float inputY;

    InputAction[] actionsToHandle;

    public FirstPersonCamState(StateMachine s) : base(s)
    {
        this.offset = Vector3.zero;
        this.targetPos = this.cam.target.position + offset;
        this.snapTime = 0.5f;
        this.startTime = Time.time;
        this.frac = 0;

        actionsToHandle = new InputAction[2] { this.cam.InputHandler.Standard.Movement, this.cam.InputHandler.Standard.Attack };

        //yuck
        this.player = cam.target.parent.Find("Character");
    }

    #region State Events
    public override void OnStateEnter()
    {
        cam.DisableActions(actionsToHandle);
        
        //Simply ensure the camera looks forward relative to player when the snaping phase ends
        this.inputX = player.rotation.eulerAngles.y;

        base.OnStateEnter();
    }

    public override void OnStateExit()
    {
        cam.EnableActions(actionsToHandle);
        base.OnStateExit();
    }

    public override void StateFixedUpdate()
    {
        if (frac < 1)
            SnapCameraToPlayersHead();
        else
            RotateCameraWithPlayerInput();      
    }

    //Not handling user input in update is inconsistent but avoids having to do additional if checks for if the camera is still snapping
    //Should probably be HACKED
    public override void StateUpdate() { }

    #endregion

    #region State Logic
    
    void SnapCameraToPlayersHead()
    {
        frac = ((Time.time - startTime) / snapTime);

        //Move
        cam.transform.position = Vector3.Lerp(
           cam.transform.position,
           this.targetPos,
           this.frac);

        //Rotate
        cam.transform.rotation = Quaternion.Lerp(
            cam.transform.rotation,
            player.rotation,
            this.frac);
    }

    void RotateCameraWithPlayerInput()
    {
        this.inputX += cam.InputDir.x * cam.firstPersonSpeed;
        this.inputY += cam.InputDir.y * cam.firstPersonSpeed;

        inputX = Mathf.Clamp(
            inputX, 
            player.rotation.eulerAngles.y - cam.firstPersonXClamp, 
            player.rotation.eulerAngles.y + cam.firstPersonXClamp);

        inputY = Mathf.Clamp(
            inputY, 
            -cam.firstPersonYClamp, 
            cam.firstPersonYClamp);

        this.cam.transform.rotation = Quaternion.Euler(
            inputY,
            inputX,
            0);
    }
    #endregion
}
