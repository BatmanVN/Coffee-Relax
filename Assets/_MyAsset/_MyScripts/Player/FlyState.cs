using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyState : Istate<PlayerStatus>
{
    public void OnEnter(PlayerStatus state)
    {
        
    }

    public void OnExcute(PlayerStatus state)
    {
        if (state.playerFly.isFly)
        {
            state.playerFly.MovementOnRail();
            state.controller.enabled = false;
        }
        if (!state.playerFly.isFly)
        {
            state.ChangeState(state.runState);
            state.controller.enabled = true;
        }
    }

    public void OnExit(PlayerStatus state)
    {
        
    }
}
