using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class AmmoPickup : PickupBase
{
    public int ammoAmount;

    /// Play pickupSFX
    /// Destroy ammoPickup
    /// Increase maxAmmo value by X ammount
    /// Start respawn timer and when it's equal to '0' respawn ammo pickup
    /// Play respawnSFX when respawn timer equals 0
    protected override void ApplyEffect(GameObject player)
    {

    }
}