using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PatrolPoints: States
{
    public ChaseState chaseState;
    public bool canSeePlayer;
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    Vector3 target;


    // Start is called before the first frame update
    void Start()
    {
        //Get NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }


    void GotoNextPoint()
    {
        //Set the destination to the next patrol point
        destPoint++;
        //Check if current patrol point is last in array
        if(destPoint == points.Length)
        {
            //Set current patrol point to be the first
            destPoint = 0;

        }
    }
    // Update is called once per frame
    void Update()
    {

        // Choose next location when near current one
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            UpdateDestination();
            GotoNextPoint();

    }
    //Set movement to be towards current patrol point
    void UpdateDestination()
    {
        //Set target to be current patrol points location
        target = points[destPoint].position;
        //Set agent to head for the target
        agent.SetDestination(target);

    }

    public override States RunCurrentState()
    {
        if (canSeePlayer)
        {
            return chaseState;
        }
        else
        {
            return this;
        }
    }
}
