using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class WeaponPickup : PickupBase
{
    protected override void ApplyEffect(GameObject player)
    {
        CharacterBase charBase = (CharacterBase)player.GetComponent<CharacterBase>();
        var onCharacter = player.GetComponent<WeaponMachineGun>();
        Debug.Log("player has machine gun: " + onCharacter);
        if (onCharacter != null)
        {
            Debug.Log("Weapon Already Exists On Player");
        }
        else
        {
            player.AddComponent<WeaponMachineGun>();
            charBase.RegisterWeapons();
        }
    }
}