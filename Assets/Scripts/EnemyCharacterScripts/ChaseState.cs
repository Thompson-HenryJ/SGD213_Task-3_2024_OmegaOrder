using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : States
{
    Transform player;
    private NavMeshAgent agent;
    public AttackState attackState;
    public bool isInAttackRange;
    FieldOfView fov;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        fov = GetComponent<FieldOfView>();
    }
    private void Update()
    {
        if (fov.canSeePlayer)
        {
            Chase();
        }
    }
    void Chase()
    {
        //Set the characters target location to playercharacters location
        agent.SetDestination(player.position);
        
    }

    //Reference to states class to run the state machine to set enemy to change state

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
