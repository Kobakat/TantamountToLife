using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    InputHandler ih = null;
    [SerializeField] Player player = null;

    void Awake() 
    {
        ih = new InputHandler();
        player = GetComponent<Player>();
    }

    private void OnEnable()
    {       
        ih.Standard.Attack.performed += OnAttack;
        ih.Standard.Movement.performed += OnMove;
        ih.Standard.Movement.canceled += OnStop;
        ih.Enable();
    }

    private void OnDisable()
    {
        
        ih.Standard.Attack.performed -= OnAttack;
        ih.Standard.Movement.performed -= OnMove;
        ih.Standard.Movement.canceled -= OnStop;
        ih.Disable();
    }

    void OnAttack(InputAction.CallbackContext context)
    {
        player.SetState(new AttackState(player));
    }

    void OnMove(InputAction.CallbackContext context)
    {
        player.SetState(new OrbitState(player));
    }

    void OnStop(InputAction.CallbackContext context)
    {
        player.SetState(new IdleState(player));
    }
    

    void Update()
    {
        player.inputDir = ih.Standard.Movement.ReadValue<Vector2>();
    }




    //TODO
    //Find a way to use these
    //Locks player movement (ideally while attacking/falling/etc)
    void Lock()
    {
        ih.Standard.Movement.Disable();
    }

    void Unlock()
    {
        ih.Standard.Movement.Enable();
    }
}
