using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    private State currentState;
    
    public void SwitchState(State state)
    {
        currentState?.Exit();
        currentState = state;
        if (currentState == null) { Debug.Log("state is null fix it"); }
        currentState.Enter();
    }
    private void Update()
    {
        currentState?.Tick();
    }
}
