using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldLoot : Interactable
{
    public int goldValue;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            other.GetComponent<Player>().Interactables.Add(this);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            other.GetComponent<Player>().Interactables.Remove(this);
    }

    public override void InteractionEvent()
    {
        Player.gold += goldValue;
        Destroy(this.gameObject);
    }
}
