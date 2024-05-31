using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour, IWeapon
{
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
        currentClip = maxClip;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public string weaponName;
    
    // Stores the current ammunition that the character holds for this
    int currentAmmo { get; set; }
    public int CurrentAmmo { get { return currentAmmo; } }

    // Stores the maximum ammunition that the character can hold for this weapon
    int maxAmmo { get; set; }
    public int MaxAmmo { get { return maxAmmo; } }

    // Stores the current amount of ammunition that is in this weapons ammo clip
    int currentClip { get; set; }
    public int CurrentClip { get { return currentClip; } }

    // Stores the maximum amount of ammunition that can be held in this weapons ammo clip
    int maxClip { get; }
    public int MaxClip { get { return maxClip; } }
    
    // Stores a reference to the type of ammunition that the weapon shoots
    GameObject projectile { get; }
    public GameObject Projectile { get { return projectile; } }

    protected float lastFiredTime = 0f;
    [SerializeField]
    public float fireDelay = 1f;

    // Functionality for firing the weapon
    public virtual void Fire()
    {
        float currentTime = Time.time;
        if (currentTime - lastFiredTime > fireDelay)
        {
            if (currentClip > 0)
            {
                currentAmmo--;
                currentClip--;
                Instantiate(projectile); // Add bullet spawn location & direction   
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