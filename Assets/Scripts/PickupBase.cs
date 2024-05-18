using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickups
{
    public float respawnDelay = 10;
    public object respawnSFX;
    public object pickupSFX;
    bool respawn = true;

    /// - Check if interaction is with playercharacter
    /// - If false do nothing, if true and health pickup increase playercharacter health by X
    /// 
    /// - if ammo pickup increase the maxammo or current ammo by X
    /// - Finally if it's the weapon pickup and is the same weapon do nothing but if the weapon is different
    /// 
    /// - Remove current weapon on player character, add weapon on pickup to character
    /// - For all pickups after interection with playercharacter destroy the pickup object + play pickupSFX
    /// - Start respawntimer (respawn delay) and once respawned play respawnSFX
}

class healthPickup : Pickups
{
    public float healAmount; 

    /// If health pickup...increase playercharacters health by X ammount
 
}

class ammoPickup : Pickups
{
    public int ammoAmount; 

    /// Ammo pickup, increase maxAmmo ammount by X ammount
}

class weaponPickup : Pickups
{
    public object weapon;
    bool collectionEnabled = true;

    /// Is interaction with Playercharacter 
    /// Remove or destroy current weapon
    /// Add new weapon to playercharacter
}