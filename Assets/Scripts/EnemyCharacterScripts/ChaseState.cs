using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : States
{
    public Transform player;
    private NavMeshAgent agent;
    public AttackState attackState;
    public bool isInAttackRange;

    private void Start()
    {
        player = GameObject.Find("PlayerCharacter").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    void Chase()
    {
        agent.SetDestination(player.position);
    }
    public override States RunCurrentState()
    {
        if (isInAttackRange)
        {
            return attackState;
        }

        else
        {
            return this;

        }
    }
}
