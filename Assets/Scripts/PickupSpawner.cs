using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PickupType
{
    public string typeName;
    public GameObject pickupPrefab;
}

public class PickupSpawner : MonoBehaviour
{
    [SerializeField]
    public PickupType[] pickupTypes;
    public bool spawnOnStart = true;
    public bool respawn = true;
    public float respawnCD = 5f;
    private float lastSpawnTime;

    void start()
    {
        if(spawnOnStart == true)
        {
            //Debug.Log("Pickup spawned on spawn");
            SpawnPickups();
        }
    }

    void Update()
    {
        GameObject[] pickups = GameObject.FindGameObjectsWithTag("Pickup");
        if(respawn && pickups.Length == 0 && Time.time > lastSpawnTime + respawnCD)
        {
            //Debug.Log("Pickup spawned");
            SpawnPickups();
        }
        else
        {
            //Debug.Log("Pickup cannot spawn");
            //Debug.Log(respawn);
            //Debug.Log(pickups.Length);
        }
    }

    void SpawnPickups()
    {
        foreach (PickupType pickupType in pickupTypes)
        {
            Vector3 spawnPosition = transform.position + Vector3.up;
            Instantiate(pickupType.pickupPrefab, spawnPosition, Quaternion.identity);
        }
        lastSpawnTime = Time.time;
    }
}
