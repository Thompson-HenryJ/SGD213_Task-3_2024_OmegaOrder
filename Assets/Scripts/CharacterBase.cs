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
        //set activeWeaponSlot to 1 for the initial weapon to be selected
        activeWeaponSlot = 1;

        //Populate ourRigidBody
        ourRigidBody = GetComponent<Rigidbody>();

    }

    public void MoveForward(float moveForward)
    {
        // make character walk forward or backward based on their walk speed
        //transform.localPosition = transform.forward * moveForward * walkSpeed * Time.deltaTime;
        ourRigidBody.velocity =  moveForward * transform.forward * walkSpeed;
    }

    public void MoveRight(float moveRight)
    {
        // make character move left or right based on their walk speed
        ourRigidBody.velocity = moveRight * transform.right * walkSpeed;
    }

    /*
    public void Reload()
    {
        //Check if the input for reload has been trigger
        if (Input.GetButton("Reload") /*| Input.GetButton("ReloadController")*)
        {

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
        }
    }
            */
}
