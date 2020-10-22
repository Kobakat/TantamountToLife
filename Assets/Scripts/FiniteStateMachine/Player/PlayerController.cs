using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputHandler ih = null;
    PlayerStateMachine player = null;

    void Start() 
    {
        this.player = this.GetComponent<PlayerStateMachine>();
    }

    private void OnEnable()
    {       
        this.ih.Standard.Attack.performed += OnAttack;
        
        this.ih.Standard.Movement.performed += OnOrbitStart;
        this.ih.Standard.Movement.canceled += OnOrbitStop;
        
        this.ih.Standard.Target.performed += OnTargetStart;
        this.ih.Standard.Target.canceled += OnTargetStop;

        this.ih.Enable();
    }

    private void OnDisable()
    {      
        this.ih.Standard.Attack.performed -= OnAttack;

        this.ih.Standard.Movement.performed -= OnOrbitStart;
        this.ih.Standard.Movement.canceled -= OnOrbitStop;

        this.ih.Standard.Target.performed -= OnTargetStart;
        this.ih.Standard.Target.canceled -= OnTargetStop;

        this.ih.Disable();
    }

    void OnAttack(InputAction.CallbackContext context)
    {
        player.SetState(new AttackState(player));
    }

    void OnOrbitStart(InputAction.CallbackContext context)
    {
        player.SetState(new OrbitState(player));
    }

    void OnOrbitStop(InputAction.CallbackContext context)
    {
        player.SetState(new IdleState(player));
    }

    void OnTargetStart(InputAction.CallbackContext context)
    {
        player.SetState(new TargetState(player));
    }

    void OnTargetStop(InputAction.CallbackContext context)
    {
        player.SetState(new IdleState(player));
    }
    

    void Update()
    {
        player.inputDir = ih.Standard.Movement.ReadValue<Vector2>();
    }

    /*TODO
    /Find a way to use these
    /Locks player movement (ideally while attacking/falling/etc)
    public static void LockPlayerMovement()
    {
        ih.Standard.Movement.Disable();
    }

    public static void UnlockPlayerMovement()
    {
        ih.Standard.Movement.Enable();
    }*/
}
