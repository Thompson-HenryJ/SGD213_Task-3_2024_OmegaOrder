using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPistol : WeaponBase
{
    [SerializeField]
    public GameObject projectile;
    public int maxAmmo;
    public int maxClip;
    // Start is called before the first frame update
    void Start()
    {
        weaponName = "Pistol";
        maxAmmo = 54;
        maxClip = 9;
        fireDelay = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
