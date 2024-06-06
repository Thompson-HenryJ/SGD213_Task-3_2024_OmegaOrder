using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Summary
/// 
///

public interface IHealth
{
   // The amount of health the object currently has 
   float CurrentHealth { get; }

   // The max health the object can have 
   float MaxHealth { get; }

   // The amount of shield the object currently has 
   float CurrentShield { get; }

   // The max amount of shield the object can have
   float MaxShield { get; }

   // How long it's been since the object last took damage
   float DamageTime { get; }

   // Time of the last regenerating of shield hitpoints
   float ShieldPulseTime { get; }

   // Amount of time after taken damage before begin recharging
   float RechargeDelay { get; }

   // The time between the shield's recharge pulses
   float RechargeInterval { get; }

   // Amount the shield recharges each pulse (cycle)
   float RechargeAmount { get; }

   // The time which the object's health is zero
   float DeathTime { get; }

   // The delay to destroy an object after the objects health is zero
   float DestroyDelay { get; }


   // Reduces X amount of health from object 
   void TakeDamage(float damageAmount);

   // Increases health of current object
   void Heal(float HealAmount);

   // What happens when the objects health equals zero
   void Death();
}
