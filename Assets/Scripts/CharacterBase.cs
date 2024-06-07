using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public abstract class CharacterBase : MonoBehaviour
{
    //Declare all variables
    public Rigidbody ourRigidBody;
    public float characterHeight;
    public int activeWeapon;
    [SerializeField]
    public Component [] weapons;
    public float walkSpeed = 10f;
    public float verticalRotation = 0f;
    public WeaponBase primaryWeapon;

    // Start is called before the first frame update
    public virtual void Start()
    {
        // Populate ourRigidBody
        ourRigidBody = GetComponent<Rigidbody>();
        RegisterWeapons();
        primaryWeapon = (WeaponBase)weapons[activeWeapon];

        if (weapons != null)
        {
            // set activeWeapon to 0 for the initial weapon to be selected
            activeWeapon = 0;
        }
        else
        {
            Debug.Log("No weapons added.");
        }
    }

    public void Move(float moveForward, float moveRight) 
    {
        ourRigidBody.AddRelativeForce(new Vector3(moveRight, 0, moveForward));
    }

    public void LookRight(float lookRight) // make character turn right or left
    {
        ourRigidBody.transform.Rotate(0, lookRight, 0, Space.Self);
    }

    public void LookUp(float lookUp) // make character look up or down
    {
        verticalRotation = lookUp;
    }

    public virtual void Reload() // Tell the weapon component to reload it's ammunition
    {
        if (weapons != null)
        {
            primaryWeapon = (WeaponBase)weapons[activeWeapon];
            primaryWeapon.Reload();
        }
        else
        {
            Debug.Log("No Weapons Attached");
        }
    }

    public virtual void Shoot() // Tell the weapon component to fire
    {
        if (weapons != null)
        {
            primaryWeapon = (WeaponBase)weapons[activeWeapon];
            primaryWeapon.Fire();
        }
        else
        {
            Debug.Log("No Weapons Attached");
        }
    }

    public virtual void RegisterWeapons()
    {
        Array.Clear(weapons, 0, weapons.Length);
        weapons = GetComponents<WeaponBase>();
        // Debug.Log(weapons.Length + " weapons added to " + this);
    }
}
