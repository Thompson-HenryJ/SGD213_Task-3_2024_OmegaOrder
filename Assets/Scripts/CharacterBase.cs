using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{


    //Declare all variables
    public Rigidbody ourRigidBody;
    public float characterHeight;
    public int activeWeaponSlot;
    [SerializeField]
    public GameObject weapon1;
    public float walkSpeed = 500f;



    // Start is called before the first frame update
    void Start()
    {
        //weapon1 = GetComponents<WeaponBase>();

        // set activeWeaponSlot to 1 for the initial weapon to be selected
        activeWeaponSlot = 1;

        // Populate ourRigidBody
        ourRigidBody = GetComponent<Rigidbody>();

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
            if (activeWeaponSlot == 1)
            {
               // weapon1.Reload();// tell Weapon1 to run it's reload function.
            }
            else
            {
                Debug.Log("No Weapon Attached");
            }
        }
    }

    public virtual void Shoot() // Tell the weapon component to fire
    {
        if (weapon1 != null)
        {
            if (activeWeaponSlot == 1)
            {
                // weapon1.Fire();
            }
            else
            {
                Debug.Log("Shoot(): Active Weapon outside of parameters or not set");
            }
        }
        else
        {
            Debug.Log("No Weapons Attached");
        }
    }
}
