using System;
using UnityEngine;

public class PlayerWeaponTrigger : MonoBehaviour
{
    Collider weapon = null;
    void Start()
    {
        weapon = this.GetComponent<Collider>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
            this.weapon.enabled = false;
    }
}
