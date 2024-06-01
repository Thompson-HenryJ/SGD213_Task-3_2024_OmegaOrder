using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    PlayerCharacter playerCharacter;
    float cameraVerticalRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = this.GetComponentInParent<PlayerCharacter>();
        // Hide the cursor and lock it's position
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //collect mouse input

        float lookUp = Input.GetAxis("LookUp");


        //Rotate the Camera around local XAxis
        cameraVerticalRotation -= lookUp;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);//Limited vertical rotation to +90 and -90
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation; //Vector3.right is rotating around the XAxis
        playerCharacter.verticalRotation = this.transform.eulerAngles.x; //Store the cameras rotation around XAxis on the PlayerCharacter

    }
}
