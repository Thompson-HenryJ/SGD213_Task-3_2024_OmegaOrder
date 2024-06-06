using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : CharacterBase
{
    

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();  // Run everything from Start in the abstract base class first.

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //When adding enemy shoot functionality, if clip runs out of ammo they will need to call the reload function on the weapon
}
