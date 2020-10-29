using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Binds a player character and a camera together with one input handler
/// </summary>


public class PlayerCamBind : MonoBehaviour
{
    Player player = null;
    CameraController cam = null;
    InputHandler ih = null;


    void Awake()
    {
        this.player = this.GetComponentInChildren<Player>();
        this.cam = this.GetComponentInChildren<CameraController>();
        this.ih = new InputHandler();

        cam.InputHandler = this.ih;
        player.InputHandler = this.ih;

    }
}
