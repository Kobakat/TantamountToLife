using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmTree : MonoBehaviour
{
    Coconut[] coconuts;
    bool struck = false;
    void Start()
    {
        coconuts = GetComponentsInChildren<Coconut>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Weapon") && !struck)
        {
            foreach (Coconut coconut in this.coconuts)
            {
                coconut.GetComponent<Rigidbody>().isKinematic = false;
                coconut.GetComponent<Rigidbody>().AddExplosionForce(5000, coconut.transform.position, 2.0f);
            }

            struck = true;
        }

    }
}
