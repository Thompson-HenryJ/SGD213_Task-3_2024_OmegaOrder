using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGrenade : WeaponBase
{
    [SerializeField]
    public GameObject projectile;
    public int maxAmmo;
    public int maxClip;

    // Start is called before the first frame update
    void Start()
    {
        weaponName = "Grenade";
        maxAmmo = 5;
        maxClip = maxAmmo;
        fireDelay = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
