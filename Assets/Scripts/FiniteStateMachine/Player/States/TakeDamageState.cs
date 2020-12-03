using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TakeDamageState : PlayerState
{
    InputAction[] actionsToHandle;
    float startTime;
    float animLength;

    public TakeDamageState(StateMachine s) : base(s)
    {
        actionsToHandle = new InputAction[4] 
        { 
            this.player.InputHandler.Standard.Movement, 
            this.player.InputHandler.Standard.Attack, 
            this.player.InputHandler.Standard.Target, 
            this.player.InputHandler.Standard.FirstPersonCam 
        };
    }

    #region State Events

    public override void StateUpdate()
    {
        ReturnToNormalStateWhenAnimationFinishes();
    }

    public sealed override void StateFixedUpdate() { }


    public sealed override void OnStateEnter()
    {
        player.DisableActions(actionsToHandle);
        SetMaterialShader("Custom/Character");

        TakeDamage();
        
        SetAnimationInfo();

        if (player.health <= 0)
        {
            player.SetState(new DyingState(player));
        }
        
    }

    public sealed override void OnStateExit()
    {
        player.EnableActions(actionsToHandle);
        SetVulnerableAfterDelay();      
    }
    #endregion

    #region State Logic

    void SetAnimationInfo()
    {
        this.startTime = Time.time;

        player.Anim.CrossFade("Male Damage Light", 0);

        this.animLength = player.Anim.runtimeAnimatorController.animationClips[0].length / 2;

    }
    void ReturnToNormalStateWhenAnimationFinishes()
    {
        if (Time.time > startTime + animLength)
        {
            player.SetState(new OrbitState(player));
        }
            
    }

    void SetMaterialShader(string shaderPath)
    {
        foreach (Material mat in player.Mats)
        {
            mat.shader = Shader.Find(shaderPath);

            if (shaderPath == "Custom/Character")
                mat.SetFloat("_Speed", 15);
        }
    }

    void TakeDamage()
    {
        player.health -= 2;
        player.isVulnerable = false;
    }

    void SetVulnerableAfterDelay()
    {
        player.StartCoroutine(Vulnerable());      
    }

    IEnumerator Vulnerable()
    {
        yield return new WaitForSeconds(player.invulnerabilityTime);

        player.isVulnerable = true;
        this.SetMaterialShader("Standard (Specular setup)");
    }
    #endregion
}
