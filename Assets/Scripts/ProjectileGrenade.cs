using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGrenade : ProjectileBase
{

    public override void Start()
    {
        base.Start();
        ourRigidBody.AddForce(transform.forward * speed);
    }

    public override void Update()
    {

    }
}
