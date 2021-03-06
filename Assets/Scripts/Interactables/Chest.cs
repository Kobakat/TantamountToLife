﻿using System;
using UnityEngine;

public class Chest : Interactable
{
    [SerializeField] GameObject LootType = null;
    AudioSource Audio = null;
    Transform spawn1, spawn2;
    void Start()
    {
        spawn1 = transform.Find("LootTarget1");
        spawn2 = transform.Find("LootTarget2");

        Audio = this.GetComponent<AudioSource>();
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
        Audio.Play();
        SpawnLoot();
    }

    void SpawnLoot()
    {
        Instantiate(LootType, spawn1.position, spawn1.rotation, this.transform);
        Instantiate(LootType, spawn2.position, spawn2.rotation, this.transform);
    }
}
