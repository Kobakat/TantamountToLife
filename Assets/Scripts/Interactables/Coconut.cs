using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coconut : MonoBehaviour
{
    [SerializeField] float heartSpawnPercentChance = 30;
    [SerializeField] GameObject HealthPickup;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Weapon"))
        {
            SpawnHeartByChance();
            DestroyCoconut();      
        }
    }

    void SpawnHeartByChance()
    {
        float roll = Random.Range(0, 100.0f);
        
        if(roll <= heartSpawnPercentChance)
        {
            Instantiate(HealthPickup, this.transform.position, this.transform.rotation);
        }
    }

    void DestroyCoconut()
    {
        //TODO play particle effect
        this.gameObject.SetActive(false);
    }
}
