using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class AmmoPickup : PickupBase
{
    [SerializeField] public int ammoAmount;
    CharacterBase ourCharacterBase; // Reference to the player's character base component
    int activeWeapon; // Index of the currently active weapon from the array of held weapons by player character
    WeaponBase primaryWeapon; // Reference to the component for the weapon
    
    protected override void ApplyEffect(GameObject player)
    {

        ourCharacterBase = (CharacterBase)player.GetComponent<CharacterBase>(); // Storing the reference of the character base component
        
        activeWeapon = ourCharacterBase.activeWeapon; // Setting the index to the same stored on the player character

        primaryWeapon = (WeaponBase)ourCharacterBase.weapons[activeWeapon]; // Finding the weapon base component stored in the array

        primaryWeapon.AddAmmo(ammoAmount); // Telling that component to increase the ammo count
        PlayerCharacter playerRef = (PlayerCharacter)player.GetComponent<PlayerCharacter>(); // Reference to player character component on player object
        playerRef.UpdateHUDAmmo(); // Calls the HUD ammo update function 

    }
}