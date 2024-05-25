using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : States
{
    public override States RunCurrentState()
    {
        Debug.Log("I have Attacked!");
        return this;
    }
}
