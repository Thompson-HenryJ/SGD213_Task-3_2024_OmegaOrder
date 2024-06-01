using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : CharacterBase
{

    public float secondaryWeapon;
    [SerializeField]
    public float jumpSpeed = 100;
   

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        activeWeapon = 1;
    }

    public void Update()
    {
        // Get player inputs for movement of character
        float moveForward = Input.GetAxis("Forward");
        float moveRight = Input.GetAxis("Strafe");

        // Call Move from CharacterBase to make player move forward/backwards and right/left
        Move(moveForward, moveRight);

        // Get player inputs for rotation of character. Vertical rotation managed by PlayerCameraController
        float lookRight = Input.GetAxis("LookRight");

        //Rotates the character left and right.
        LookRight(lookRight);

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetButtonDown("Shoot"))
        {
            Shoot();
        }
    }

    public override void Reload() // Tell the weapon component to reload it's ammunition
    {
        if (Input.GetButton("Reload")) // | Input.GetButton("ReloadController")
        {
            Debug.Log("No Weapon Attached");
        }
    }

    public void SwapWeapon()
    {
    
        Debug.Log("WeaponSwap(): Active Weapon outside of parameters or not set");
        /* Insert anything that happens for the weapon swap... ie. Updating the HUD graphics
         */
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
