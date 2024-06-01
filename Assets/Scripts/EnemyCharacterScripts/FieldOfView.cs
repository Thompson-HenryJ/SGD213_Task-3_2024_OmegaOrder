using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0,360)]
    public float angle;
    public float delay = 0.2f;
    public bool canSeePlayer;
    public GameObject playerRef;

    //Declaration of layermasks to create obstructions
    public LayerMask targetMask;
    public LayerMask obstructionMask;
   


    private void Start()
    {
        //Set playerRef to be playercharacter
        playerRef = GameObject.FindGameObjectWithTag("Player");
        //Start Coroutine for delay to not call the function every frame (Performance saving)
        StartCoroutine(FOVRoutine());
     
    }

    private IEnumerator FOVRoutine()
    {
        //Feeds delay through amount of seconds
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (true)
        {
            //Continue calling functionality of Coroutine
            yield return wait;
            FieldOfViewCheck();

        }
    }

    private void FieldOfViewCheck()
    {
        //sets up collider array to check for overlaps
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        //checks if something has come in range
        if(rangeChecks.Length != 0)
        {
            // checks if overlap is player
            Transform target = rangeChecks[0].transform;
            // checks direction towards target(Player)
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            //checks angle towards target
            if(Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                //distance to player is within range
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                //does a final check that plaeyr can be seen
                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    //player is confirmed so set player to visible
                    canSeePlayer = true;

                }
                else
                {
                    //Can't find player so set player to not visible
                    canSeePlayer = false;
                }
            }
            else
            {
                //Player is out of range so set player to not visible
                canSeePlayer = false;
            }
        }
        else if(canSeePlayer)
        {
            //Player is no longer visbile so set player to not visible
            canSeePlayer = false;
        }
    }

    
}
