using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStateMachine : StateMachine
{
    public Transform target = null;

    public float height;
    public float distFromPlayer;

    void Start() { this.SetState(new OrbitCamState(this)); }

    void Update() { this.state.StateUpdate(); }

    void FixedUpdate() { this.state.StateFixedUpdate(); }
}
