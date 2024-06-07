using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class WeaponPickup : PickupBase
{

    protected override void ApplyEffect(GameObject player)
    {
        // References to other objects
        CharacterBase charBase = (CharacterBase)player.GetComponent<CharacterBase>();
        PlayerCharacter playerCharacter = (PlayerCharacter)player.GetComponent<PlayerCharacter>();
        // Does the player already have the weapon attached?
        var onCharacter = player.GetComponent<WeaponMachineGun>();
        if (onCharacter != null)
        {
            Debug.Log("Weapon Already Exists On Player");
        }
        else
        {
            player.AddComponent<WeaponMachineGun>();  // Attach the new weapon to the character
            charBase.RegisterWeapons(); // Tell the character to re-register it's list of weapons
            playerCharacter.activeWeapon = charBase.weapons.Length - 1; // Set the new active weapon to be the latest weapon attached
            playerCharacter.primaryWeapon = (WeaponBase)charBase.weapons[playerCharacter.activeWeapon]; // Equip the new active weapon in the primary slot
            playerCharacter.UpdateHUDAmmo();  // Update the ammo count on the HUD.
        }
    }
}