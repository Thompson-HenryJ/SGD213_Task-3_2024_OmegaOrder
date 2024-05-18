using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : CharacterBase
{

    public GameObject weapon2;
    [SerializeField]
    public float jumpSpeed = 100;

    // Start is called before the first frame update
    void Start()
    {
        //weapon2 = GetComponent<WeaponBase>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        // get player inputs for movement of character
        float moveForward = Input.GetAxis("Forward");
        float moveRight = Input.GetAxis("Strafe");
        Debug.Log("Move Forward:" + moveForward + " Move Right: " + moveRight);

        // Call Move from CharacterBase to make player move forward/backwards and right/left
        Move(moveForward, moveRight);

        // get player inputs for rotation of character
        float lookUp = Input.GetAxis("LookUp");
        float lookRight = Input.GetAxis("LookRight");
        Debug.Log("Look Up:" + lookUp + " Look Right: " + lookRight);

        // Call Move from CharacterBase to make player move forward/backwards and right/left
        LookRight(lookRight);
        LookUp(lookUp);

    }


    public override void Reload() // Tell the weapon component to reload it's ammunition
    {
        if (Input.GetButton("Reload")) // | Input.GetButton("ReloadController")
        {
            if (activeWeaponSlot == 1)
            {
               // weapon1.Reload(); // tell Weapon1 to run it's reload function.
            }
            else if (activeWeaponSlot == 2)
            {
               // weapon2.Reload(); // tell Weapon2 to run it's reload function.
            }
            else
            {
                Debug.Log("No Weapon Attached");
            }
        }
    }

    public void SwapWeapon()
    {
        if (activeWeaponSlot == 1)
        {
            activeWeaponSlot = 2;
        }
        else if (activeWeaponSlot == 2)
        {
            activeWeaponSlot = 1;
        }
        else
        {
            Debug.Log("WeaponSwap(): Active Weapon outside of parameters or not set");
        }
        /* Insert anything that happens for the weapon swap... ie. Updating the HUD graphics
         */
    }

    public override void Shoot() // Tell the weapon component to fire
    {
        if (weapon1 != null)
        {
            if (activeWeaponSlot == 1)
            {
                // weapon1.Fire();
            }
            else if (activeWeaponSlot == 2)
            {
                // weapon2.Fire();
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
 
    public void Jump()
    {
        ourRigidBody.AddForce(0, jumpSpeed, 0, ForceMode.Impulse);
    }
    ///<summary> 
    /// public void ThrowGrenade()
    /// {

    /// }



    /// public void Crouch()
    /// {

    /// }

    /// </summary>
}