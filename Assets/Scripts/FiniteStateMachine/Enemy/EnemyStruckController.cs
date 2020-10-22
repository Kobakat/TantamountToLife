using UnityEngine;

/*HACK
 *This is a demo script and will be replaced with a modular class structure mostly identical to the player's later
 */

public class EnemyStruckController : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerWeaponTrigger.EnemyStruck += OnEnemyStruck;
    }

    private void OnDisable()
    {
        PlayerWeaponTrigger.EnemyStruck -= OnEnemyStruck;
    }

    void OnEnemyStruck(ParticleSystem ps, Rigidbody rb)
    {
        ps.Play();

        float x = Random.Range(0.5f, 1);
        float z = Random.Range(0.5f, 1);

        int xdir = 1 - 2 * Random.Range(0, 2);
        int zdir = 1 - 2 * Random.Range(0, 2);

        x *= xdir;
        z *= zdir;


        rb.AddForce(x * 500, 0, z * 500, ForceMode.Impulse);
    }
}
