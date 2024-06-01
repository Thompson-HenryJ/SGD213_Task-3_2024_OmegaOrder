using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{

    public Transform playerCharacter;
    float cameraVerticalRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Hide the cursor and lock it's position
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //collect mouse input
        float inputX = Input.GetAxis("LookRight");
        float inputY = Input.GetAxis("LookUp");


        //Rotate the Camera around local XAxis
        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        //Rotate the player obkect and the camera around the YAxis

        playerCharacter.Rotate(Vector3.up * inputX);

    }
}
