using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class WeaponPistol : WeaponBase
{
    private void Awake()
    {
        weaponName = "Pistol";
        maxAmmo = 54;
        maxClip = 9;
        fireDelay = 1;
        projectile = Resources.Load("Proj_Bullet") as GameObject;
        currentAmmo = maxAmmo;
        currentClip = maxClip;
    }
}
