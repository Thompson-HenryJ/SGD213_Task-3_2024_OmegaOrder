using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class HealthPickup : PickupBase
{
    public float healAmount;

    /// Play pickupSFX
    /// Destroy healthPickup
    /// Increase playerCharacters health by X ammount (Max Health being the limit)

    /// Start respawn timer and when it's equal to '0' respawn health pickup
    /// Play respawnSFX when respawn timer equals 0
    protected override void ApplyEffect(GameObject player)
    {

    }
}