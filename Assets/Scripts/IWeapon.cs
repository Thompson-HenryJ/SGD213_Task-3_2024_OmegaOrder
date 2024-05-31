using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    // Stores the current ammunition that the character holds for this
    int CurrentAmmo { get; }

    // Stores the maximum ammunition that the character can hold for this weapon
    int MaxAmmo { get; }

    // Stores the current amount of ammunition that is in this weapons ammo clip
    int CurrentClip { get; }

    // Stores the maximum amount of ammunition that can be held in this weapons ammo clip
    int MaxClip { get; }

    // Stores a reference to the type of ammunition that the weapon shoots
    GameObject Projectile { get; }


    // Functionality for firing the weapon
    void Fire();

    // Functionality for increasing the weapons ammunition
    void AddAmmo(int AmmoAmount);

    // Functionality for reloading the weapon
    void Reload();
}
