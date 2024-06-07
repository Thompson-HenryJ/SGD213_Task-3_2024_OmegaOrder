using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMachineGun : WeaponBase
{
    private void Awake()
    {
        weaponName = "MachineGun";
        maxAmmo = 100;
        maxClip = 30;
        fireDelay = 0.1f;
        projectile = Resources.Load("Proj_Bullet") as GameObject;
        currentAmmo = maxAmmo;
        currentClip = maxClip;
    }
}
