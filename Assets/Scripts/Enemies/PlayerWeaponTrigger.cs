using System;
using UnityEngine;

/*HACK
 *This is a demo script and will be replaced with a modular class structure mostly identical to the player's later
 */

public class PlayerWeaponTrigger : MonoBehaviour
{
    ParticleSystem ps;
    Rigidbody rb;
    void Start()
    {
        this.ps = GetComponent<ParticleSystem>();
        this.rb = GetComponent<Rigidbody>();
    }

    public static event Action<ParticleSystem, Rigidbody> EnemyStruck;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            if (EnemyStruck != null)
            {
                EnemyStruck.Invoke(this.ps, this.rb);
            }
        }
    }
}
