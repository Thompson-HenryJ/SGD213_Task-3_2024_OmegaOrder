using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupBase
{
    public float respawnDelay = 10;
    public AudioClip respawnSFX;
    public AudioClip pickupSFX;
    protected bool respawn = true;

    /// - Check if it's the playerCharacter thats interacting with the pickup
    /// - False = do nothing
    /// - True = follow respective pickup below

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayPickupSound();
            ApplyEffect(other.gameObject);
            Destroy(gameObject);
            StartRespawnTimer();
        }
    }

    protected abstract void ApplyEffect(GameObject player);

    protected virtual void PlayerPickupSound()
    {
        if (pickupSFX != null)
        {
            AudioSource.PlayClipAtPoint(pickupSFX, transform.position);
        }
    }

    protected virtual void StartRespawnTimer()
    {
        respawn = false;
        Invoke(nameof(Respawn), respawnDelay);
    }

    protected virtual void Respawn()
    {
        respawn = true;
        if(respawnSFX != null)
        {
            AudioSource.PlayClipAtPoint(respawnSFX, transform.position);
        }
    }
}

class healthPickup : PickupBase
{
    public float healAmount; 

    /// Play pickupSFX
    /// Destroy healthPickup
    /// Increase playerCharacters health by X ammount (Max Health being the limit)
    
    /// Start respawn timer and when it's equal to '0' respawn health pickup
    /// Play respawnSFX when respawn timer equals 0
 
}

class ammoPickup : PickupBase
{
    public int ammoAmount; 

    /// Play pickupSFX
    /// Destroy ammoPickup
    /// Increase maxAmmo value by X ammount
    /// Start respawn timer and when it's equal to '0' respawn ammo pickup
    /// Play respawnSFX when respawn timer equals 0

}

class weaponPickup : PickupBase
{
    public object weapon;
    bool collectionEnabled = true;

    /// If 'weaponPickup == currentWeapon' then 'collectionEnabled = False' then do nothing and return
    
    /// If 'weaponPickup != currentWeapon' then 'collectionEnabled = True' then do the following below
    /// playerCharacter's current weapon = Destroyed
    /// playerCharacter picks up the new weapon
    /// Start respawn timer 
    /// timer = 0 then spawn new weapon
    /// Play respawnSFX when respawn timer equals 0

}