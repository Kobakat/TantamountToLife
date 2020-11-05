using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState : State
{
    protected Enemy enemy;

    public EnemyState(StateMachine s) : base(s)
    {
        this.stateMachine = s;
        this.enemy = (Enemy)this.stateMachine;
    }
}

