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

    // Reduces X amount of health from object 
    public void TakeDamage(float damageAmount)
    {
        // Check if the character has a shield (ie maxShield is greater than zero)
        if (maxShield > 0)
        {
            Debug.Log("Enemy hit by bullet - has shield.");
            // Recording the last time the object took damage
            damageTime = Time.time;
            // StopRecharge();
            if (damageAmount > currentShield) // Is the damageAmount more than the currentShield
            {
                // Reduce health by the amount of damage the shield doesn't absorb and then set the shield to 0.
                currentHealth = damageAmount - currentShield;
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
            StartRecharge();
        }
        else
        {
            currentHealth = currentShield - damageAmount; // Reduce health by damage amount

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

    public void StartRecharge()
    {
        startShieldDelay = ShieldDelay(rechargeDelay);
        StartCoroutine(startShieldDelay);
    }

    public void StopRecharge()
    {
        StopCoroutine(startShieldDelay);
        StopCoroutine(startShieldPulse);
    }

    private IEnumerator ShieldDelay(float shieldDelay)
    {
        yield return new WaitForSeconds(shieldDelay);
        startShieldPulse = ShieldPulser(rechargeInterval);
        StartCoroutine(startShieldPulse);
    }

    private IEnumerator ShieldPulser(float shieldPulseTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(shieldPulseTime);
            if (currentShield >= maxShield)
            {
                currentShield = maxShield;
                StopCoroutine(startShieldPulse);
            }
            else if (maxShield - currentShield > rechargeAmount)
            {
                currentShield = maxShield;
                StopCoroutine(startShieldPulse);
            }
            else
            {
                currentShield += rechargeAmount;
            }
        }
    }

    // Increases health of current object
    public void Heal(float healAmount)
    {
        Debug.Log("Heal function called");

        if (maxHealth - currentHealth < healAmount)
        {

            currentHealth = maxHealth;
            // Debug.Log(currentHealth);
        }
        else
        {

            currentHealth = currentHealth + healAmount;
            // Debug.Log(currentHealth);
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
            playerRef.Restart();
        }
        else
        {
            // else set Enemy State to Dead
            this.GetComponent<Collider>().enabled = false;// disable the collider so the enemy stops interacting with other objects
            Destroy(GetComponent<Rigidbody>());
            // Add in any death effects here
            Destroy(gameObject, 2);
        }
    }
}