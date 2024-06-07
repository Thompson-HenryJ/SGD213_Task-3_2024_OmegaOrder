using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacter : CharacterBase
{

    public int secondaryWeapon;
    [SerializeField]
    public float jumpSpeed = 100;
    private AmmoDisplay HUD;
    public WeaponBase grenadeLauncher;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        activeWeapon = 1;
        secondaryWeapon = 1;
        HUD = (AmmoDisplay)GameObject.Find("AmmoDisplay").GetComponent<AmmoDisplay>(); // Set a reference to the ammo display on the HUD Canvas.
        UpdateHUDAmmo();  // Update
        grenadeLauncher = (WeaponBase)weapons[0]; // Set the grenade to be the first WeaponBase component attached to the character.
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

        if (Input.GetButtonDown("Reload"))
        {
            Reload();
            UpdateHUDAmmo();
        }

        if (Input.GetButtonDown("SwapWeapons"))
        {
            SwapWeapon();
        }
        
        if (Input.GetButtonDown("Restart"))
        {
            Restart();
        }
    }

   

    public void SwapWeapon()
    {
        if (weapons.Length > 2)
        {
            Debug.Log(activeWeapon + " / " + secondaryWeapon);
            int tempWeapon1 = activeWeapon;
            int tempWeapon2 = secondaryWeapon;
            activeWeapon = tempWeapon2;
            secondaryWeapon = tempWeapon1;
            Debug.Log(activeWeapon + " / " + secondaryWeapon);
            primaryWeapon = (WeaponBase)weapons[activeWeapon]; // Equip the new active weapon in the primary slot

        }
        else
        {
            Debug.Log("No secondary weapon equipped.");
        }
        UpdateHUDAmmo();
        /* Insert anything that happens for the weapon swap... ie. Updating the HUD graphics */
    }

    public void Jump()
    {
        ourRigidBody.AddForce(0, jumpSpeed, 0, ForceMode.Impulse);
    }

    public void ThrowGrenade()
    {
        grenadeLauncher.Fire();
    }

    public override void Shoot()
    {
        base.Shoot();
        UpdateHUDAmmo();
    }

    public void Restart()
    {
        StartCoroutine(ReloadScene());
    }

    public IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateHUDAmmo()
    {
        HUD.UpdateAmmo(primaryWeapon.currentAmmo, primaryWeapon.maxAmmo, primaryWeapon.currentClip, primaryWeapon.maxClip);
    }
}
