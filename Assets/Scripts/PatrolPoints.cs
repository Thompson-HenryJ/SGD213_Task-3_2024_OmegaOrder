using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PatrolPoints: MonoBehaviour
{

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        //Get NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();

        //Disable auto-braking to allow enemy to not slow down when approaching point
        agent.autoBraking = false;

        GotoNextPoint();

    }


    void GotoNextPoint()
    {
        //Returns if no points have been set up
        if (points.Length == 0)
            return;

        //Set the agent to go to next location
        agent.destination = points[destPoint].position;

        // Choose the next point in array as location
        destPoint = (destPoint + 1) % points.Length;
    }
    // Update is called once per frame
    void Update()
    {
        
        // Choose next location when near current one
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();

    }
}
