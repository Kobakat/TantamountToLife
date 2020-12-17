using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldLoot : Interactable
{
    public int goldValue;

    ParticleSystem particle = null;
    AudioSource Audio = null;

    void Start()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        Audio = GetComponent<AudioSource>();
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
        Player.gold += goldValue;

        foreach (MeshRenderer renderer in GetComponentsInChildren<MeshRenderer>())
            renderer.enabled = false;

        Audio.Play();
        particle.Stop();
        this.GetComponent<Collider>().enabled = false;
    }
}
