using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour
{
    public Rigidbody ourRigidBody;
    [field: SerializeField] float damageRadius;
    [field: SerializeField] public float speed;

    // Start is called before the first frame update
    public virtual void Start()
    {
        ourRigidBody = GetComponent<Rigidbody>();
        Debug.Log("Bullet Spawned - Forward: " + ourRigidBody.transform.forward);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        ourRigidBody.AddForce(transform.forward * speed);
        Debug.Log("Bullet location on x: " + ourRigidBody.transform.position.x + " y: " + ourRigidBody.transform.position.y + " z: " + ourRigidBody.transform.position.z);
    }
}
