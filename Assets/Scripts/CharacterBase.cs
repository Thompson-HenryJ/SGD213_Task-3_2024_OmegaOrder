using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{
    //Declare all variables
    public Rigidbody ourRigidBody;
    public float characterHeight;
    public int activeWeapon;
    [SerializeField]
    public Component [] weapons;
    public float walkSpeed = 10f;

    // Start is called before the first frame update
    public virtual void Start()
    {
        // Populate ourRigidBody
        ourRigidBody = GetComponent<Rigidbody>();
        weapons = GetComponents<WeaponBase>();
        Debug.Log(weapons.Length + " weapons added to " + this);

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
        
    }

    public virtual void Reload() // Tell the weapon component to reload it's ammunition
    {
        if (Input.GetButton("Reload")) // | Input.GetButton("ReloadController")
        {
            Debug.Log("No Weapon Attached");
        }
    }

    public virtual void Shoot() // Tell the weapon component to fire
    {
        if (weapons != null)
        {    
            Debug.Log("Shoot(): Active Weapon outside of parameters or not set");
        }
        else
        {
            Debug.Log("No Weapons Attached");
        }
    }
}
