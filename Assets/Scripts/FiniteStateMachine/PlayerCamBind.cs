using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Binds a player character and a camera together with one input handler

public class PlayerCamBind : MonoBehaviour
{
    PlayerController pc = null;
    CameraController cc = null;
    public InputHandler ih = null;

    void Awake()
    {
        pc = this.GetComponentInChildren<PlayerController>();
        cc = this.GetComponentInChildren<CameraController>();
        ih = new InputHandler();

        cc.ih = this.ih;
        pc.ih = this.ih;
    }
}
