using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class HealthPickup : PickupBase
{
    [SerializeField] public float healAmount; // The amount of health the pickup will give the player character upon collision

    protected override void ApplyEffect(GameObject other)
    {
        if (other.GetComponent<IHealth>() != null) // Checking if the 'other' game object has a component that implements IHealth 
        {
            other.GetComponent<IHealth>().Heal(healAmount); // If it's true then apply the effect, add the specified health to the player
        } else {
             Debug.Log(other.name + " does not have an IHealth component"); // If false, do nothing
        }
    }
}