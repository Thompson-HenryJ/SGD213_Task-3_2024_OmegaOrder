using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    GameObject playerCharacter;
    Health health;
    float currentHealth;
    float maxHealth;

    void Start()
    {
        //Find any game object with player tag
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
        //Get component on the object that manages the health
        health = (Health)playerCharacter.GetComponent<Health>();
        //Declares current health variable
        currentHealth = health.CurrentHealth;

        //Declares max health variable
        maxHealth = health.MaxHealth;
        //Converts the maximum value of the healthbar to be maxHealth
        healthBar.maxValue = maxHealth;


    }

    void Update()
    {
        //update the health bar to value of current health
        healthBar.value = currentHealth;

    }
}
