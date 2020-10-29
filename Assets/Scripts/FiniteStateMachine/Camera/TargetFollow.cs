using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    [SerializeField] Transform player = null;
    Vector3 offset;
    void Start()
    {
        this.offset = this.transform.position;
    }
    void FixedUpdate()
    {
        this.transform.position = player.transform.position + offset;
    }
}
