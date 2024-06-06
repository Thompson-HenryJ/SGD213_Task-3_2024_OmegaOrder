using System.Collections;
using System.Collections.Generic;
using UnityEngine;



class WeaponPickup : PickupBase
{
    [SerializeField] component pickupWeaponName;
    
    protected override void ApplyEffect(GameObject player)
    {

        /// <summary>
        /// Check to see if the weapon on the pickup is on the player
        /// if (Player.trygetcomponent<pickupweaponName>() != null)
        /// { * }
        /// else {  
        /// (player.addComponent(pickupWeaponName));
        /// get reference to characterbase
        /// Characterbase.weapons.add(pickupWeaponName);}
        /// If its on the player do nothing
        /// If not, add weapon to the game object and add the component to the array
        /// </summary>


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

        if (characterBase.weapons == null || characterBase.weapons.Length == 0)
        {
            Debug.LogError("No weapons found on player");
            return;
        }

        Debug.Log("CharacterBase has " + characterBase.weapons.Length + " weapons");
        foreach (WeaponBase weapon in characterBase.weapons)
        {
           
            if (weapon != null)
            {
                Debug.Log("Weapon on player: " + weapon.weaponName);
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