using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HumanBaseState : State
{
    protected readonly HumanStateMachine stateMachine;

    protected HumanBaseState(HumanStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

}
