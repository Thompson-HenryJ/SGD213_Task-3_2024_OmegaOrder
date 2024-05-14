using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : CharacterBase
{

    

    // Start is called before the first frame update
    void Start()
    {
      
    }

    public void Inputs()
    {
        //Check if MoveForward input is being used
        float moveForward = Input.GetAxis("Forward");
        //if (moveForward != 0.0f)
       // {
            Debug.Log("Move Forward Variable" + moveForward);
            // Call MoveForward from CharacterBase to make player move forward or backwards depending on value
            MoveForward(moveForward);
     //   }
    }
}
