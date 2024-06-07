using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour
{
    public Rigidbody ourRigidBody;
    [field: SerializeField] public float speed;
    [field: SerializeField] public float damageAmount;
    private SphereCollider ourCollider;


    // Start is called before the first frame update
    public virtual void Start()
    {
        ourCollider = GetComponent<SphereCollider>();
        ourRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        ourRigidBody.AddForce(transform.forward * speed); // propel the bullet forward each frame
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IHealth>() != null) // if the object it collides with has the IHealth component
        {
            other.GetComponent<IHealth>().TakeDamage(damageAmount); // tell the object to take damage
        }
        else
        {
            Destroy(gameObject); // destroy the other object
        }
        Destroy(gameObject); // destroy the projectile
    }
}
