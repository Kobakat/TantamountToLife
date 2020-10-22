using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Binds a player character and a camera together with one input handler

public class PlayerCamBind : MonoBehaviour
{
    PlayerController pc = null;
    CameraController cc = null;
    InputHandler ih = null;

    void Awake()
    {
        this.pc = this.GetComponentInChildren<PlayerController>();
        this.cc = this.GetComponentInChildren<CameraController>();
        this.ih = new InputHandler();

        cc.ih = this.ih;
        pc.ih = this.ih;
    }
}
