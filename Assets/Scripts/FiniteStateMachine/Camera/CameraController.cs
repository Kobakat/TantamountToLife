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
    
    public float freeCamSpeed;
    public float freeCamYClamp;

    public float firstPersonSpeed;
    public float firstPersonXClamp;
    public float firstPersonYClamp;

    public int layermask = 10;
    
    #endregion

    #region Unity Event Functions
    void Start()
    {
        this.SetState(new OrbitCamState(this));
    }

    private void OnEnable()
    {
        this.InputHandler.Standard.Target.performed += OnTargetStart;
        this.InputHandler.Standard.FreeCam.performed += OnFreeCam;
        this.InputHandler.Enable();
    }

    private void OnDisable()
    {
        this.InputHandler.Standard.Target.performed -= OnTargetStart;
        this.InputHandler.Standard.FreeCam.performed -= OnFreeCam;
        this.InputHandler.Disable();
    }

    void Update()
    {
        this.InputDir = InputHandler.Standard.FreeCam.ReadValue<Vector2>();
        this.state.StateUpdate();
        CheckForWallColiision();
    }

    void FixedUpdate() { this.state.StateFixedUpdate(); }

    #endregion

    #region Input Delegates
    void OnTargetStart(InputAction.CallbackContext context) { this.SetState(new TargetCamState(this)); }

    void OnFreeCam(InputAction.CallbackContext context) 
    { 
        if(this.state.GetType() != typeof(FreeCamState))    
            this.SetState(new FreeCamState(this)); 
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

    #region Wall Collision

    void CheckForWallColiision()
    {
        RaycastHit hit = new RaycastHit();

        if (Physics.Linecast(target.position, transform.position, out hit))
        {           
            if(hit.transform.gameObject.layer == layermask) 
            {
                this.transform.position = hit.point;
            }
        }
    }

    #endregion
}
