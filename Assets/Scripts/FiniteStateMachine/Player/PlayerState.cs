using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rather than downcasting in every state designed for a player, an intermediary class can do so
/// Also helps with organization
/// </summary>

public abstract class PlayerState : State
{
    protected Player player;

    public PlayerState(StateMachine s) : base(s)
    {
        this.stateMachine = s;
        this.player = (Player)this.stateMachine;
    }
}
