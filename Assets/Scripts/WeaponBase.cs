using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Vector3 bulletSpawn { get; set; }
    public Vector3 BulletSpawn {  get { return bulletSpawn; } }

    // Start is called before the first frame update
    public void Start()
    {
        currentAmmo = maxAmmo;
        currentClip = maxClip;
        Debug.Log(this.name + ". CurrentAmmo: " + currentAmmo + ". CurrentClip: " + currentClip + ".");
        bulletSpawn = this.transform.position;
    }

    // Update is called once per frame
    public void Update()
    {

    }

    // Functionality for firing the weapon
    public virtual void Fire()
    {
        float currentTime = Time.time;
        GameObject newbullet;
        if (currentTime - lastFiredTime > fireDelay)
        {
            if (currentClip > 0)
            {
                currentAmmo--;
                currentClip--;
                newbullet = Instantiate(projectile); // Add bullet spawn location & direction
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
    public virtual void AddAmmo(int AmmoAmount)
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
    public virtual void Reload()
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
        //Check if ammoCount is less than 0. If it is set to 0.
        else if (currentAmmo < 0)
        {
            currentAmmo = 0;
            Debug.Log("ammoCount Reset to '0'");
        }
    }
}