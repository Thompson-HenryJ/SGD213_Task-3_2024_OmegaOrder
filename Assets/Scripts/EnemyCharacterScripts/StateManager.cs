using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    States currentState;
    PatrolPoints patrolPoints;
    ChaseState chaseState;
    AttackState attackState;
    void Start()
    {
        currentState = patrolPoints;
    }

    void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        States nextState = currentState?.RunCurrentState();

        if (nextState != null)
        {
            SwitchToNextState(nextState);
        }
    }

    private void SwitchToNextState(States nextState)
    {
        currentState = nextState;
    }

}
