using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class WeaponBase : MonoBehaviour, IWeapon
{
    [field: SerializeField] public string weaponName { get; set; }
    public string WeaponName { get { return weaponName; } }
    
    // Stores the current ammunition that the character holds for this
    public int currentAmmo { get; set; }
    public int CurrentAmmo { get { return currentAmmo; } }

    // Stores the maximum ammunition that the character can hold for this weapon
    [field: SerializeField] public int maxAmmo { get; set; }
    public int MaxAmmo { get { return maxAmmo; } }

    // Stores the current amount of ammunition that is in this weapons ammo clip
    public int currentClip { get; set; }
    public int CurrentClip { get { return currentClip; } }

    // Stores the maximum amount of ammunition that can be held in this weapons ammo clip
    [field: SerializeField] public int maxClip { get; set; }
    public int MaxClip { get { return maxClip; } }

    // Stores a reference to the type of ammunition that the weapon shoots
    [field: SerializeField] public GameObject projectile { get; set; }
    public GameObject Projectile { get { return projectile; } }

    public float lastFiredTime { get; set; }
    public float LastFiredTime { get { return lastFiredTime; } }

    [field: SerializeField] public float fireDelay { get; set; }
    public float FireDelay { get { return fireDelay; } }



    // Functionality for firing the weapon
    public virtual void Fire()
    {
        Vector3 spawnPosition;
        float currentTime = Time.time;
        GameObject newbullet;
        CharacterBase characterBase = (CharacterBase)GetComponent<CharacterBase>();

        if (currentTime - lastFiredTime > fireDelay)
        {
            if (currentClip > 0)
            {
                spawnPosition = transform.position + transform.forward * 1.5f;
                float xRot = characterBase.verticalRotation;
                float yRot = this.transform.eulerAngles.y;
                float zRot = this.transform.eulerAngles.z;
                currentAmmo--;
                currentClip--;
                newbullet = Instantiate(projectile, spawnPosition, Quaternion.Euler(xRot, yRot, zRot)); // Add bullet spawn location & direction
                lastFiredTime = Time.time;

            }
            else if (currentClip == 0)
            {
                // play out of ammo sfx;
            }
            else
            {
                Debug.Log("Current Clip Ammo less than 0.");
            }
        }
    }

    // Functionality for increasing the weapons ammunition
    public void AddAmmo(int AmmoAmount)
    {
        int missingAmmo = maxAmmo - currentAmmo;
        if (missingAmmo > 0)
        {
            if (AmmoAmount <= missingAmmo)
            {
                currentAmmo =+ AmmoAmount;
            }
            else
            {
                currentAmmo += missingAmmo;
            }
        }
        else
        {
            Debug.Log("Current Ammo already exceeded maximum ammo count.");
            currentAmmo = maxAmmo;
        }
    }

    // Functionality for reloading the weapon
    public void Reload()
    {
        //check if clip is full
        if (currentClip == maxClip)
        {
            Debug.Log("Clip is full");
        }
        //Check if ammoCount is equal to 0. If it is do not reload.
        else if (currentAmmo == 0)
        { 
            //play out of ammo SFX
            Debug.Log("Out Of Ammo");
        }
        //Check if ammoCount is less than 0. If it is set to 0.
        else if (currentAmmo < 0)
        {
            currentAmmo = 0;
            Debug.Log("ammoCount Reset to '0'");
        }
        //Checks if current clip contains all remainging ammo
        else if (currentClip == currentAmmo)
        {
            Debug.Log("Clip contains all remainging ammo");
        }
        //Checks if ammo count is more than 0 and clip is missing ammo
        else if (currentAmmo > 0 && currentClip != maxClip)
        {
            if (currentAmmo >= maxClip)
            {
                currentClip = maxClip;
            }
            else
            {
                currentClip = currentAmmo;
            }
            Debug.Log("reloading");
        }
    }
}