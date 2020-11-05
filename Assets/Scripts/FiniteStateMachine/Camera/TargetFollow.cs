using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    [SerializeField] Transform player = null;
    [SerializeField] Vector3 offset = Vector3.zero;

    void FixedUpdate()
    {
        this.transform.position = player.transform.position + offset;
    }
}
