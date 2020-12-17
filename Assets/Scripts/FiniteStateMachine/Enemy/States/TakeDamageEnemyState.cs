using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageEnemyState : EnemyState
{
    float startTime;
    float animLength;

    public TakeDamageEnemyState(StateMachine s) : base(s)
    {

    }

    #region State Events

    public override void StateUpdate()
    {
        ReturnToNormalStateWhenAnimationFinishes();
    }

    public sealed override void StateFixedUpdate() { }


    public sealed override void OnStateEnter()
    {
        enemy.health -= 2;

        SetMaterialShader();
        PlaySVFX();
        SetAnimationInfo();

        if (enemy.health <= 0)
        {
            enemy.SetState(new DyingEnemyState(enemy));
        }

    }

    public sealed override void OnStateExit()
    {
        SetMaterialShader("Standard (Specular setup)");
    }
    #endregion

    #region State Logic

    void SetAnimationInfo()
    {
        this.startTime = Time.time;

        enemy.Anim.Play("Male Damage Light", 0);

        this.animLength = enemy.Anim.runtimeAnimatorController.animationClips[0].length / 2;

    }

    

    void ReturnToNormalStateWhenAnimationFinishes()
    {
        if (Time.time > startTime + animLength)
            enemy.SetState(new AttackEnemyState(enemy));
    }

    void SetMaterialShader()
    {
        foreach (Material mat in enemy.Mats)
        {
            mat.shader = enemy.damageShader;
        }
    }

    void SetMaterialShader(string shaderPath)
    {
        foreach (Material mat in enemy.Mats)
        {
            mat.shader = Shader.Find(shaderPath);
        }
    }

    void PlaySVFX()
    {
        enemy.Particle.Play();

        int choice = Random.Range(0, 2);

        switch(choice)
        {
            case 0:
                enemy.Audio.PlayOneShot(enemy.hitOne);
                break;
            case 1:
                enemy.Audio.PlayOneShot(enemy.hitTwo);
                break;
        }
    }

    #endregion
}
