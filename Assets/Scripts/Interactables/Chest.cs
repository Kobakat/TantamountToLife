using System;
using UnityEngine;

public class Chest : Interactable
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            other.GetComponent<Player>().Interactable = this;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            other.GetComponent<Player>().Interactable = null;
    }

    public override void InteractionEvent()
    {
        this.GetComponent<Collider>().enabled = false;
        this.GetComponentInChildren<HingeJoint>().useMotor = true;
    }
}
