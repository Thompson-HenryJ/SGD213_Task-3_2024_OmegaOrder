using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    // The amount of health the object currently has 
    [SerializeField] protected float currentHealth;
    public float CurrentHealth { get { return currentHealth; } }

   // The max health the object can have 
   [SerializeField] protected float maxHealth;
   public float MaxHealth { get { return maxHealth; } }

   // The amount of shield the object currently has 
   protected float currentShield;
   public float CurrentShield { get { return currentShield; } }

   // The max amount of shield the object can have
   [SerializeField] protected float maxShield;
   public float MaxShield { get { return maxShield; } }

   // How long it's been since the object last took damage
   protected float damageTime;
   public float DamageTime { get { return damageTime; } }

   // Time of the last regenerating of shield hitpoints
   protected float shieldPulseTime;
   public float ShieldPulseTime { get { return shieldPulseTime; } }

   // Amount of time after taken damage before begin recharging
   [SerializeField] protected float rechargeDelay;
   public float RechargeDelay { get { return rechargeDelay; } }

   // The time between the shield's recharge pulses
   [SerializeField] protected float rechargeInterval;
   public float RechargeInterval { get { return rechargeInterval; } }

   // Amount the shield recharges each pulse (cycle)
   [SerializeField] protected float rechargeAmount;
   public float RechargeAmount { get { return rechargeAmount; } }

   // The time which the object's health is zero
   protected float deathTime;
   public float DeathTime { get { return deathTime; } }

   // The delay to destroy an object after the objects health is zero
   protected float destroyDelay;
   public float DestroyDelay { get { return destroyDelay; } }


   

   // Reduces X amount of health from object 
   public void TakeDamage(float damageAmount)
   {
        // Check the maxShield is greater than zero
        
        if (maxShield > 0)
        {
            // Recording the last time the object took damage
            damageTime = Time.time;

            StopRecharge();

            if (damageAmount > currentShield) // Is the damageAmount more than the currentShield
            {
                // Subtract damageamount from currentshield and remaining from currentHealth
                currentHealth = damageAmount - currentShield;
                currentShield = 0;

                if (currentHealth <= 0) // If it kills the object
                {
                    Death();
                }
                else
                {
                    // Play shieldDepletedSFX
                    
                    StartRecharge();
                }
      
            }
            else
            {
                currentShield = currentShield - damageAmount;
                // Play hurtSFX
                StartRecharge();
            }
        }
        else
        {
            currentHealth = currentHealth - damageAmount;

            if(currentHealth <= 0)
            {
                Death();
            }
            else
            {
                // Play hurtSFX
            }
        }

   }

   // Increases health of current object
   public void Heal(float healAmount)
   {
        Debug.Log("Heal function called");

       if(maxHealth - currentHealth < healAmount)
       {
            
            currentHealth = maxHealth;
            Debug.Log(currentHealth);
       }
       else
       {
            
            currentHealth = currentHealth + healAmount;
            Debug.Log(currentHealth);
       }
   }

   // What happens when the objects health equals zero
   public void Death()
   {

   }

   // Starts shield recharge cycle
   public void StartRecharge()
   {
        shieldPulseTime = damageTime;

        if(Time.time - rechargeDelay > damageTime)
        {
            
        }
        else
        {

        }

   }

   // Stops the shields recharge cycle
   public void StopRecharge()
   {

   }

   // When the current shield amount reaches zero
   public void ShieldDepleted()
   {

   }
}

