using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR.Haptics;

public interface IControllable
{
    InputHandler InputHandler {get; set;}

    void EnableActions(InputAction[] Actions);
    void DisableActions(InputAction[] Actions);
}
