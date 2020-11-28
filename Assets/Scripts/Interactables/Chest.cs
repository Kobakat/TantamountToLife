using System;
using UnityEngine;

public class Chest : Interactable
{
    [SerializeField] GameObject LootType;

    Transform spawn1, spawn2;
    void Start()
    {
        spawn1 = transform.Find("LootTarget1");
        spawn2 = transform.Find("LootTarget2");
    }
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
        this.GetComponent<Collider>().enabled = false;
        this.GetComponentInChildren<HingeJoint>().useMotor = true;

        SpawnLoot();
    }

    void SpawnLoot()
    {
        Instantiate(LootType, spawn1.position, spawn1.rotation);
        Instantiate(LootType, spawn2.position, spawn2.rotation);
    }
}
