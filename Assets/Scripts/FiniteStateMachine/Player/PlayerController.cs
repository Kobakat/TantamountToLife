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
        this.ih.Standard.Movement.performed += OnMoveStart;
        this.ih.Standard.Movement.canceled += OnMoveStop;
        this.ih.Enable();
    }

    private void OnDisable()
    {      
        this.ih.Standard.Attack.performed -= OnAttack;
        this.ih.Standard.Movement.performed -= OnMoveStart;
        this.ih.Standard.Movement.canceled -= OnMoveStop;
        this.ih.Disable();
    }

    void OnAttack(InputAction.CallbackContext context)
    {
        player.SetState(new AttackState(player));
    }

    void OnMoveStart(InputAction.CallbackContext context)
    {
        player.SetState(new OrbitState(player));
    }

    void OnMoveStop(InputAction.CallbackContext context)
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
