using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    Enemy enemy;
    void Start()
    {
        enemy = transform.parent.parent.Find("Character").GetComponent<Enemy>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.SetState(new AttackEnemyState(enemy));
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.SetState(new PursueEnemyState(enemy));           
        }
    }

}
