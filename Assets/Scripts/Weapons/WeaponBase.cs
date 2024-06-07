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

        if (currentTime - lastFiredTime > fireDelay) // make sure enough time has elapsed since the last shot before shooting again
        {
            if (currentClip > 0) // make sure the clip has ammo
            {
                spawnPosition = transform.position + transform.forward * 1.5f; // set a point in front of the character so it's not shooting itself
                float xRot = characterBase.verticalRotation; // use the value stored here instead of the object rotation because the gameobject doesn't rotate when looking up and down
                float yRot = this.transform.eulerAngles.y; // rotation of the game object looking left and right
                float zRot = this.transform.eulerAngles.z; // should be 0 because the characters don't lean left and right
                currentAmmo--; // reduce the total held ammo by 1
                currentClip--; // reduce the ammo in the clip by 1
                newbullet = Instantiate(projectile, spawnPosition, Quaternion.Euler(xRot, yRot, zRot)); // Spawn a bullet
                lastFiredTime = Time.time; // set the last time the bullet was fired to right now

            }
            else if (currentClip == 0) // if the clip is out of ammo
            {
                // play out of ammo sfx
                Debug.Log(this.weaponName + "has no ammo in the clip and didn't fire.");
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