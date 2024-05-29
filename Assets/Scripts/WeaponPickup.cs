using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class WeaponPickup : PickupBase
{
    public object weapon;
    // bool collectionEnabled = true;

    /// If 'weaponPickup == currentWeapon' then 'collectionEnabled = False' then do nothing and return

    /// If 'weaponPickup != currentWeapon' then 'collectionEnabled = True' then do the following below
    /// playerCharacter's current weapon = Destroyed
    /// playerCharacter picks up the new weapon
    /// Start respawn timer 
    /// timer = 0 then spawn new weapon
    /// Play respawnSFX when respawn timer equals 0
    protected override void ApplyEffect(GameObject player)
    {

    }
}