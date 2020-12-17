using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmTree : MonoBehaviour
{
    Coconut[] coconuts;
    AudioSource Audio = null;

    bool struck = false;
    void Start()
    {
        coconuts = GetComponentsInChildren<Coconut>();
        Audio = this.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Weapon") && !struck)
        {
            Audio.Play();
            foreach (Coconut coconut in this.coconuts)
            {
                coconut.GetComponent<Rigidbody>().isKinematic = false;
                coconut.GetComponent<Rigidbody>().AddExplosionForce(5000, coconut.transform.position, 2.0f);
            }

            struck = true;
        }

    }
}
