using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGrenade : WeaponBase
{
    private void Awake()
    {
        weaponName = "Grenade";
        maxAmmo = 5;
        maxClip = 5;
        fireDelay = 3;
        projectile = Resources.Load("Proj_Grenade") as GameObject;
    }
}
