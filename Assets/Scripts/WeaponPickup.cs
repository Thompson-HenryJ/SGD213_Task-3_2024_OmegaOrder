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
        // Check if player holds weapon1 or weapon2

        // If weapon1, then do the following
        // Check if weapon1 == weaponPickup, if true do nothing and return
        // If false then then change set new weapon as weapon1

        // If weapon2, do the same but with weapon2
    }
}