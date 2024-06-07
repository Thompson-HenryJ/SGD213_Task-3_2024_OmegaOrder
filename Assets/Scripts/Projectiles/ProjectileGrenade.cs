using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ProjectileGrenade : ProjectileBase
{
    [SerializeField] public float timer = 3f;
    [SerializeField] public float damageRadius= 5f;

    public override void Start()
    {
        base.Start(); // run everything in ProjectileBase.Start() first
        ourRigidBody.AddForce(transform.forward * speed); // throw the grenade
        Invoke("Detonate", timer); // start the cooldown timer for the grenade
    }

    public override void Update() // overriden so the grenade doesn't travel forward in a straight line
    {
        
    }

    protected override void OnTriggerEnter(Collider other) // overriden as this is a timed grenade and doesn't explode on impact
    {
        
    }

    protected void Detonate() 
    {
        int maxColliders = 10;
        Collider[] hitColliders = new Collider[maxColliders]; 
        int numColliders = Physics.OverlapSphereNonAlloc(transform.position, damageRadius, hitColliders); // get up to 10 nearby objects within range
        for (int i = 0; i < numColliders; i++)
        {
            if (hitColliders[i].GetComponent<IHealth>() != null) // if they have the IHealth component
            {
                hitColliders[i].GetComponent<IHealth>().TakeDamage(damageAmount); // tell them to take damage
            }
            else
            {
                Destroy(gameObject); // destroy the other object
            }
            Destroy(gameObject); // destroy the grenade
        }
    }
}
