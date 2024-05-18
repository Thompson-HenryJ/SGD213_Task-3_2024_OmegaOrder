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

        /*  Move this to the WeaponBase class.
        //Check if the input for reload has been trigger


            //check if ammo count is more than 0. If it is reload
            if (ammoCount > 0)
            {
                Debug.Log("Reloading");
            }
            //Check if ammoCount is equal to 0. If it is do not reload.
            else if (ammoCount == 0)
            {
                Debug.Log("Out Of Ammo");
            }
            // Check if ammoCount exists on character. If it doesn't print to Debug.Log
            else if (ammoCount == null)
            {
                Debug.Log("Attach ammoCount Variable");
            }
            //Check if ammoCount is less than 0. If it is set to 0.
            else if (ammoCount < 0)
            {
                ammoCount = 0;
                Debug.Log("ammoCount Reset to '0'");
            }
        }*/
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
