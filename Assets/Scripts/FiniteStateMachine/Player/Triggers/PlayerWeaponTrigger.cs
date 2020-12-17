using System;
using UnityEngine;

public class PlayerWeaponTrigger : MonoBehaviour
{
    Collider weapon = null;
    Player player = null;
    AudioSource source = null;

    public AudioClip firstStrike = null;
    public AudioClip secondStrike = null;
    public AudioClip finalStrike = null;

    void Start()
    {
        weapon = this.GetComponent<Collider>();
        player = this.GetComponentInParent<Player>();
        source = this.GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            player.DisableWeaponCollider();
            PlayWeaponSFX();
        }          
    }

    void PlayWeaponSFX()
    {
        switch(player.hitCount)
        {
            case 1:
                source.clip = firstStrike;
                break;
            case 2:
                source.clip = secondStrike;
                break;
            case 3:
                source.clip = finalStrike;
                break;
        }

        source.PlayOneShot(source.clip);
    }
}
