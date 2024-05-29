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
    FieldOfView fov;
    private void Start()
    {
        player = GameObject.Find("PlayerCharacter").transform;
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
