using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursueEnemyState : EnemyState
{
    Quaternion look;
    Vector3 velocity;

    public PursueEnemyState(StateMachine s) : base(s)
    {
        this.look = Quaternion.identity;
        this.velocity = Vector3.zero;
    }

    public override void OnStateEnter()
    {
        enemy.EnemyCol.material = enemy.MoveMaterial;
        enemy.Anim.CrossFade("Male_Sword_Walk", 0.1f);
        base.OnStateEnter();
    }

    public override void OnStateExit() 
    {
        enemy.EnemyCol.material = enemy.StopMaterial;
        base.OnStateExit(); 
    }


    public override void StateFixedUpdate() 
    {     
        MoveTowardsPlayer();       
    }

    public override void StateUpdate() 
    {
        Rotate();
    }

    void MoveTowardsPlayer()
    {
        velocity.z = enemy.Speed;
        enemy.Rb.velocity = enemy.transform.rotation * new Vector3(0.0f, 0.0f, velocity.z) + new Vector3(0.0f, velocity.y, 0.0f);
    }

    void Rotate()
    {
        look = Quaternion.LookRotation(enemy.player.transform.position - enemy.transform.position, Vector3.up);

        enemy.transform.rotation = Quaternion.RotateTowards(enemy.transform.rotation, look, enemy.TurnSpeed * Time.deltaTime);
        
        enemy.transform.rotation = Quaternion.Euler(
            0,
            enemy.transform.rotation.eulerAngles.y,
            enemy.transform.rotation.eulerAngles.z);
    }
}
