using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupBase : MonoBehaviour
{
    [SerializeField]
    public bool spawnOnStart = true;
    public bool respawn = true;
    public float respawnCD = 20f;
    public AudioClip respawnSFX;
    public AudioClip pickupSFX;
    
    private IEnumerator respawnTimer;
    
    private BoxCollider ourCollider;
    private MeshRenderer ourMesh;
    
    protected virtual void Start()
    {
        ourCollider = GetComponent<BoxCollider>();
        ourMesh = GetComponent<MeshRenderer>();
        if (spawnOnStart != true)
        {
            Disable();
            StartRespawnTimer();
        } 
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Make sure that it's the player character that's overlapping the object
        {
            // PlayPickupSound();
            ApplyEffect(other.gameObject);
            Disable();
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

    protected virtual void Disable() // Disables the pickup by turning off overlap events and the mesh
    {
        ourCollider.enabled = false;
        ourMesh.enabled = false;

        if (respawn)
        {
            if (respawnCD > 0)
            {
                StartRespawnTimer();
            }
            else
            {
                Debug.Log(this + "is supposed to respawn but does not have a respawn cooldown set");
            }
        }
        else
        {
            Debug.Log(this + "is not set to respawn.");
        }
    }

    private IEnumerator RespawnTimer(float respawnCD)
    {
        yield return new WaitForSeconds(respawnCD);
        if (respawnSFX != null)
        {
            // AudioSource.PlayClipAtPoint(respawnSFX, transform.position);
        }
        ourCollider.enabled = true;
        ourMesh.enabled = true;
    }

    protected virtual void StartRespawnTimer() // Enables the pickup by turning on overlap events and the mesh
    {
        respawnTimer = RespawnTimer(respawnCD);
        StartCoroutine(respawnTimer);
    }
}