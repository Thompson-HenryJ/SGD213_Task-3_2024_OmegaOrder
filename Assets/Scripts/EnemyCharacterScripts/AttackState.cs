using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : States
{

    //set to be utilised in future project completion
    public override States RunCurrentState()
    {
        Debug.Log("I have Attacked!");
        return this;
    }
}
