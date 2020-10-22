using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : State
{
    //Rather than downcasting in every state designed for a player, an intermediary class can do so
    //Also helps with organization

    protected PlayerStateMachine player;

    public PlayerState(StateMachine s) : base(s)
    {
        this.stateMachine = s;
        this.player = (PlayerStateMachine)this.stateMachine;
    }
}
