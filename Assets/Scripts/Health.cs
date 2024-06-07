using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour, IHealth
{
    // The amount of health the object currently has 
    public float currentHealth;
    public float CurrentHealth { get { return currentHealth; } }

    // The max health the object can have 
    [SerializeField] protected float maxHealth;
    public float MaxHealth { get { return maxHealth; } }

    // The amount of shield the object currently has 
    public float currentShield;
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

    private IEnumerator startShieldDelay;
    private IEnumerator startShieldPulse;

    public void Start()
    {
        rechargeAmount = 1f;
        rechargeInterval = 0.5f;
        rechargeDelay = 3f;
        InvokeRepeating("ShieldPulser", rechargeDelay, rechargeInterval); ;

    }

    // Reduces X amount of health from object 
    public void TakeDamage(float damageAmount)
    {
        // Check if the character has a shield (ie maxShield is greater than zero)
        if (maxShield > 0)
        {
            Debug.Log("Enemy hit by bullet - has shield.");
            // Recording the last time the object took damage
            damageTime = Time.time;
            CancelInvoke();  // stop all existing shield regen
            if (damageAmount > currentShield) // Is the damageAmount more than the currentShield
            {
                // Reduce health by the amount of damage the shield doesn't absorb and then set the shield to 0.
                currentHealth = currentHealth - (damageAmount - currentShield);
                currentShield = 0;
                Debug.Log("Enemy hit by bullet - damage amount is greater than current shield.");
                if (currentHealth <= 0) // If it kills the character
                {
                    Death();
                }
                else
                {
                    // Play ShieldDepletedSFX
                }

            }
            else
            {
                currentShield = currentShield - damageAmount;
                // Play hurtSFX
                Debug.Log("Enemy hit by bullet - damage amount is less than current shield.");
            }
            InvokeRepeating("ShieldPulser", rechargeDelay, rechargeInterval); ;
        }
        else
        {
            currentHealth = currentHealth - damageAmount; // Reduce health by damage amount

            if (currentHealth <= 0) // If it kills the character
            {
                Death();
            }
            else
            {
                // Play hurtSFX
            }
        }

    }

    private void ShieldPulser()
    {
        if (currentShield >= maxShield) // if the current shield is already greater than the maximum shield, set it back to maximum shield and cancel the shield regen
        {
            currentShield = maxShield;
            CancelInvoke();
        }
        else if ((maxShield - currentShield) <= rechargeAmount) // if the shield regen would take it over the maximum shield amount, set it to maximum shield amount and cancel the shield regen
        {
            currentShield = maxShield;
            CancelInvoke();
        }
        else // otherwise just add the regen amount to the current shield amount
        {
            currentShield += rechargeAmount;
        }
    }

    // Increases health of current object
    public void Heal(float healAmount)
    {
        Debug.Log("Heal function called");

        if (maxHealth - currentHealth < healAmount) // if the heal would take the character above max health, set it to max health
        {

            currentHealth = maxHealth;
        }
        else // otherwise add the heal amount to the current health
        {

            currentHealth = currentHealth + healAmount;
        }
    }

    // What happens when the objects health equals zero
    public void Death()
    {
        // play deathSFX
        if (GetComponent<PlayerCharacter>() != null) // if this is the player character
        {
            Time.timeScale = 0; // Stop the game from running
            PlayerCharacter playerRef = (PlayerCharacter)GetComponent<PlayerCharacter>();
            playerRef.Restart(); // start the timer to reload the scene
        }
        else
        {
            this.GetComponent<Collider>().enabled = false;// disable the collider so the enemy stops interacting with other objects
            Destroy(GetComponent<Rigidbody>()); // disable the rigidbody to stop any other forces acting on it
            // Add in any death effects here
            Destroy(gameObject, 2); // destroy the object after 2 seconds
        }
    }
}