using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour
{
    public Rigidbody ourRigidBody;
    [field: SerializeField] public float speed;
    [field: SerializeField] public float damageAmount;
    private SphereCollider collider;


    // Start is called before the first frame update
    public virtual void Start()
    {
        collider = GetComponent<SphereCollider>();
        ourRigidBody = GetComponent<Rigidbody>();
        // Debug.Log("Bullet Spawned - Forward: " + ourRigidBody.transform.forward);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        ourRigidBody.AddForce(transform.forward * speed);
        //Debug.Log("Bullet location on x: " + ourRigidBody.transform.position.x + " y: " + ourRigidBody.transform.position.y + " z: " + ourRigidBody.transform.position.z);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        // Debug.Log (other);
        if (other.GetComponent<IHealth>() != null)
        {
            // Debug.Log("TakeDamage");
            other.GetComponent<IHealth>().TakeDamage(damageAmount);
        }
        else
        {
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
