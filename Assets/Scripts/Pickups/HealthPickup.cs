using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class HealthPickup : PickupBase
{
    [SerializeField] public float healAmount;

    protected override void ApplyEffect(GameObject other)
    {
        if (other.GetComponent<IHealth>() != null) 
        {
            other.GetComponent<IHealth>().Heal(healAmount);
        } else {
             Debug.Log(other.name + " does not have an IHealth component");
        }
    }
}