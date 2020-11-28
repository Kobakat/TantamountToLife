using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmTree : MonoBehaviour
{
    FixedJoint[] coconutJoints;
    void Start()
    {
        coconutJoints = GetComponentsInChildren<FixedJoint>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Weapon"))
        {
            foreach (FixedJoint joint in this.coconutJoints)
                Destroy(joint);
        }

    }
}
