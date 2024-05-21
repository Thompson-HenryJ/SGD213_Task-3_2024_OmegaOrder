using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour, IWeapon
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Stores the current ammunition that the character holds for this
    protected float currentAmmo;
    public float CurrentAmmo { get { return currentAmmo; } }

    // Stores the maximum ammunition that the character can hold for this weapon
    float maxAmmo { get; }
    public float MaxAmmo { get { return maxAmmo; } }

    // Stores the current amount of ammunition that is in this weapons ammo clip
    float currentClip { get; }
    public float CurrentClip { get { return currentClip; } }

    // Stores the maximum amount of ammunition that can be held in this weapons ammo clip
    float maxClip { get; }
    public float MaxClip { get { return maxClip; } }

    // Stores a reference to the type of ammunition that the weapon shoots
    GameObject projectile { get; }
    public GameObject Projectile { get { return projectile; } }

    // Functionality for firing the weapon
    public void Fire()
    {

    }

    // Functionality for increasing the weapons ammunition
    public void AddAmmo(int AmmoAmount)
    {

    }

    // Functionality for reloading the weapon
    public void Reload()
    {
        //check if ammo count is more than 0. If it is reload
        if (currentAmmo > 0)
        {
            Debug.Log("Reloading");
        }
        //Check if ammoCount is equal to 0. If it is do not reload.
        else if (currentAmmo == 0)
        {
            Debug.Log("Out Of Ammo");
        }
        // Check if ammoCount exists on character. If it doesn't print to Debug.Log
        else if (currentAmmo == null)
        {
            Debug.Log("Attach ammoCount Variable");
        }
        //Check if ammoCount is less than 0. If it is set to 0.
        else if (currentAmmo < 0)
        {
            currentAmmo = 0;
            Debug.Log("ammoCount Reset to '0'");
        }
    }
}
