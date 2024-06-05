using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : CharacterBase
{

    public int secondaryWeapon;
    [SerializeField]
    public float jumpSpeed = 100;
    AmmoDisplay HUD;
    WeaponBase grenadeLauncher;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        activeWeapon = 1;
        HUD = (AmmoDisplay)GameObject.Find("AmmoDisplay").GetComponent<AmmoDisplay>();
        HUD.UpdateAmmo(primaryWeapon.currentAmmo, primaryWeapon.maxAmmo);
        grenadeLauncher = (WeaponBase)weapons[0];
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

        if (Input.GetButtonDown("Grenade"))
        {
            ThrowGrenade();
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
        int tempWeapon1 = activeWeapon;
        int tempWeapon2 = secondaryWeapon;
        activeWeapon = tempWeapon2;
        secondaryWeapon = tempWeapon1;
        Debug.Log("Indexes for Primary and Secondary Weapons Swapped");
        HUD.UpdateAmmo(primaryWeapon.currentAmmo, primaryWeapon.maxAmmo);
        /* Insert anything that happens for the weapon swap... ie. Updating the HUD graphics
         */
    }

    public void Jump()
    {
        ourRigidBody.AddForce(0, jumpSpeed, 0, ForceMode.Impulse);
    }

    public void ThrowGrenade()
    {
        grenadeLauncher.Fire();
    }



    /// public void Crouch()
    /// {

    /// }

    /// </summary>
    /// 
    public override void Shoot()
    {

        base.Shoot();
        HUD.UpdateAmmo(primaryWeapon.currentAmmo, primaryWeapon.maxAmmo);

    }
}
