using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotate : MonoBehaviour
{
   public float rotationSpeed = 30f; // Rotation speed of the game object

    void Update() // Called once per frame
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime); // Object rotation on the y axis
    }
}
