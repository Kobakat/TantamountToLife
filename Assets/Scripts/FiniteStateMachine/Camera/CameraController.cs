using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : StateMachine, IControllable
{
    #region Properties

    public InputHandler InputHandler { get; set; }
    public Transform target = null;
   
    public Vector2 InputDir { get; set; }
    
    public float height;
    public float distFromPlayer;

    #endregion

    #region Unity Event Functions
    void Start()
    {
        this.SetState(new OrbitCamState(this));
    }

    private void OnEnable()
    {
        this.InputHandler.Standard.Target.performed += OnTargetStart;
        this.InputHandler.Standard.Target.canceled += OnTargetStop;
        this.InputHandler.Standard.FreeCam.performed += OnFreeCam;
        this.InputHandler.Enable();
    }

    private void OnDisable()
    {
        this.InputHandler.Standard.Target.performed -= OnTargetStart;
        this.InputHandler.Standard.Target.canceled -= OnTargetStop;
        this.InputHandler.Standard.FreeCam.performed -= OnFreeCam;
        this.InputHandler.Disable();
    }

    void Update()
    {
        this.InputDir = InputHandler.Standard.FreeCam.ReadValue<Vector2>();
        this.state.StateUpdate();
    }

    void FixedUpdate() { this.state.StateFixedUpdate(); }

    #endregion

    #region Input Delegates
    void OnTargetStart(InputAction.CallbackContext context) { this.SetState(new TargetCamState(this)); }
    void OnTargetStop(InputAction.CallbackContext context) { this.SetState(new OrbitCamState(this)); }

    void OnFreeCam(InputAction.CallbackContext context)
    {
        //TODO
        //Add free camera state
        //this.cam.SetState(new FreeCamState(cam));
    }

    #endregion


    #region IControllable
    public void EnableActions(InputAction[] Actions)
    {
        foreach (InputAction action in Actions)
        {
            if (action != null)
                action.Enable();
        }
    }

    public void DisableActions(InputAction[] Actions)
    {
        foreach (InputAction action in Actions)
        {
            if (action != null)
                action.Disable();
        }
    }
    #endregion
}
