using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : Istate<PlayerStatus>
{
    public void OnEnter(PlayerStatus state)
    {
        
    }

    public void OnExcute(PlayerStatus state)
    {
        if (!state.playerFly.isFly)
        {
            state.controller.player_movements2();
            state.playerFly.enabled = false;
        }
        if (state.playerFly.isFly)
        {
            state.ChangeState(state.flyState);
            state.playerFly.enabled = true;
        }
    }

    public void OnExit(PlayerStatus state)
    {
        
    }
}
