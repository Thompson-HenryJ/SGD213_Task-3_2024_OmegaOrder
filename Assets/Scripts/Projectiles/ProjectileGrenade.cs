using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGrenade : ProjectileBase
{
    [SerializeField] public float timer = 3f;
    [SerializeField] public float damageRadius= 5f;

    public override void Start()
    {
        base.Start();
        ourRigidBody.AddForce(transform.forward * speed);
        Invoke("Detonate", timer);
    }

    public override void Update()
    {

    }

    protected override void OnTriggerEnter(Collider other)
    {
        
    }

    protected void Detonate()
    {
        int maxColliders = 10;
        Collider[] hitColliders = new Collider[maxColliders];
        int numColliders = Physics.OverlapSphereNonAlloc(transform.position, damageRadius, hitColliders);
        for (int i = 0; i < numColliders; i++)
        {
            if (hitColliders[i].GetComponent<IHealth>() != null)
            {
                // Debug.Log("TakeDamage");
                hitColliders[i].GetComponent<IHealth>().TakeDamage(damageAmount);
            }
            else
            {
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }
    }
}
