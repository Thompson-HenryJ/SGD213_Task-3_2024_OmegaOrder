using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : CharacterBase
{

    

    // Start is called before the first frame update
    void Start()
    {
      
    }

    void Update()
    {
        //Check if MoveForward input is being used
        float moveForward = Input.GetAxis("Forward");
        //float moveForward = Input.GetAxis("Forward");
        if (moveForward != 0)
        {
            Debug.Log("Move Forward Variable" + moveForward);
            // Call MoveForward from CharacterBase to make player move forward or backwards depending on value
            MoveForward(moveForward);
        }

        float moveRight = Input.GetAxis("MoveRight");
        if (moveRight != 0)
        {
            Debug.Log("Move Right Variable" + moveRight);
            MoveRight(moveRight);
        
        }
    }
}
