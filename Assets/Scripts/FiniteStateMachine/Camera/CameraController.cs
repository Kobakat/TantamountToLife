using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public InputHandler ih = null;
    CameraStateMachine cam = null;

    void Start()
    {
        this.cam = GetComponent<CameraStateMachine>();
    }

    private void OnEnable()
    {
        this.ih.Standard.Target.performed += OnTargetStart;
        this.ih.Standard.Target.canceled += OnTargetStop;
        this.ih.Standard.FreeCam.performed += OnFreeCam;
        this.ih.Enable();
    }

    private void OnDisable()
    {
        this.ih.Standard.Target.performed -= OnTargetStart;
        this.ih.Standard.Target.canceled -= OnTargetStop;
        this.ih.Standard.FreeCam.performed -= OnFreeCam;
        this.ih.Disable();
    }

    void OnTargetStart(InputAction.CallbackContext context)
    {
        this.cam.SetState(new FreeCamState(cam));
    }

    void OnTargetStop(InputAction.CallbackContext context)
    {
        this.cam.SetState(new OrbitCamState(cam));
    }

    void OnFreeCam(InputAction.CallbackContext context)
    {
       
        this.cam.SetState(new FreeCamState(cam));
    }

}
