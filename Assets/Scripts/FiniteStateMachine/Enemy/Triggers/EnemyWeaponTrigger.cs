using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponTrigger : MonoBehaviour
{
    Collider weapon = null;
    void Start()
    {
        weapon = this.GetComponent<Collider>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            this.weapon.enabled = false;
    }
}
