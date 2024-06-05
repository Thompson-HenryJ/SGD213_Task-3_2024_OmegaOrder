using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class WeaponPickup : PickupBase
{
    [SerializeField] private string pickupWeaponName;
    
    protected override void ApplyEffect(GameObject player)
    {

        Debug.Log("ApplyEffect called");

         CharacterBase characterBase = player.GetComponent<CharacterBase>();
        if (characterBase == null)
        {
            Debug.LogError("Player doesn't have CharacterBase Component");
            return;
        }
        Debug.Log("CharacterBase found");

        WeaponBase currentWeapon = characterBase.primaryWeapon;
        Debug.Log("Current weapon: " + (currentWeapon != null ? currentWeapon.weaponName : "None"));

        WeaponBase newWeapon = null;

        foreach (Component weaponComponent in characterBase.weapons)
        {
            WeaponBase weapon = weaponComponent as WeaponBase;
            if (weapon != null)
            {
                Debug.Log("Checking weapon: " + weapon.weaponName);
                if (weapon.weaponName == pickupWeaponName)
                {
                    newWeapon = weapon;
                    break;
                }
            }
            else
            {
                Debug.LogWarning("Weapon component is not of type WeaponBase");
            }
        }

        if (newWeapon == null)
        {
            Debug.LogError("Weapon " + pickupWeaponName + " not found on player");
            return;
        }
        Debug.Log("New weapon found: " + newWeapon.weaponName);

        if (currentWeapon != null && currentWeapon.weaponName == newWeapon.weaponName)
        {
            Debug.Log("Player already has this weapon. No swap made.");
            return;
        }

        characterBase.primaryWeapon = newWeapon;
        characterBase.activeWeapon = System.Array.IndexOf(characterBase.weapons, newWeapon);

        Debug.Log("Weapon picked up: " + newWeapon.weaponName);

        Destroy(gameObject);
        

    }
}