using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider bar;
    GameObject playerCharacter;
    Health health;
    float current;
    float max;
    [SerializeField] bool healthshield; //type in Health or Shield


    void Start()
    {
        bar = GetComponent<Slider>();
        //Find any game object with player tag
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
        //Get component on the object that manages the health
        health = (Health)playerCharacter.GetComponent<Health>();

        if (healthshield)
        {
            //Declares max health variable
            max = health.MaxHealth;
        
        }
        else
        {
            //Declares max shield variable
            max = health.MaxShield;
           
        }
        //set the maximum value of the bar to the maximum allowed value

        bar.maxValue = max;

    }

    void Update()
    {
        if (healthshield)
        {
            //Declares current health variable
            current = health.CurrentHealth;

        }
        else
        {
            //Declares current shield variable
            current = health.CurrentShield;
        }

        //update the bar to value of current health or shield
        bar.value = current;

    }
}
