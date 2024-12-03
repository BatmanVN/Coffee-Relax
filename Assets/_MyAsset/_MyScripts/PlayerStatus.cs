using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStatus : MonoBehaviour
{
    public CharacterController controller;
    public PlayerFly playerFly;
    private Istate<PlayerStatus> currentState;
    public RunState runState;
    public FlyState flyState;

    private void OnValidate()
    {
        controller = GetComponent<CharacterController>();
        playerFly = GetComponent<PlayerFly>();
    }

    private void Start()
    {
        runState = new RunState();
        flyState = new FlyState();
        currentState = runState;
    }

    private void Update()
    {
        ControlState();
    }
    public void ChangeState(Istate<PlayerStatus> newState)
    {
        if (currentState != null)
            currentState.OnExit(this);
        currentState = newState;
        if(currentState != null)
            currentState.OnEnter(this);
    }
    public void ControlState()
    {
        if(currentState != null)
            currentState.OnExcute(this);
    }
}
