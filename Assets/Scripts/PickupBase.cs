using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupBase : MonoBehaviour
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
            // PlayPickupSound();
            ApplyEffect(other.gameObject);
            Destroy(gameObject);
            StartRespawnTimer();
            Debug.Log(other.name + "has collided with pickup");
        }
        else {
            Debug.Log(other.name + "does not have player tag");
        }
    }

    protected abstract void ApplyEffect(GameObject player);

    protected virtual void PlayerPickupSound()
    {
        if (pickupSFX != null)
        {
            // AudioSource.PlayClipAtPoint(pickupSFX, transform.position);
        }
    }

    protected virtual void StartRespawnTimer()
    {
        respawn = false;
        // Invoke(nameof(Respawn), respawnDelay);
    }

    protected virtual void Respawn()
    {
        respawn = true;
        if(respawnSFX != null)
        {
            // AudioSource.PlayClipAtPoint(respawnSFX, transform.position);
        }
    }
}