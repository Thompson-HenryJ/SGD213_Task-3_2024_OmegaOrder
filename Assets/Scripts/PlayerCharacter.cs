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
        HUD = (AmmoDisplay)GameObject.Find("AmmoDisplay").GetComponent<AmmoDisplay>();
        HUD.UpdateAmmo(primaryWeapon.currentAmmo, primaryWeapon.maxAmmo, primaryWeapon.currentClip, primaryWeapon.maxClip);
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

        if (Input.GetButtonDown("Reload"))
        {
            Reload();
            HUD.UpdateAmmo(primaryWeapon.currentAmmo, primaryWeapon.maxAmmo, primaryWeapon.currentClip, primaryWeapon.maxClip);
        }
    }

   

    public void SwapWeapon()
    {
        int tempWeapon1 = activeWeapon;
        int tempWeapon2 = secondaryWeapon;
        activeWeapon = tempWeapon2;
        secondaryWeapon = tempWeapon1;
        Debug.Log("Indexes for Primary and Secondary Weapons Swapped");
        HUD.UpdateAmmo(primaryWeapon.currentAmmo, primaryWeapon.maxAmmo, primaryWeapon.currentClip, primaryWeapon.maxClip);
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
        HUD.UpdateAmmo(primaryWeapon.currentAmmo, primaryWeapon.maxAmmo, primaryWeapon.currentClip, primaryWeapon.maxClip);

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
}
