using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoDisplay : MonoBehaviour
{
   
    int currentAmmo;
    int maxAmmo;
    public TMP_Text ammoValue;

    void Start()
    {

    }

    private void Update()
    {

        ammoValue.SetText(currentAmmo.ToString() + "|" + maxAmmo.ToString());
        
    }

    public void UpdateAmmo(int newAmmo, int newMaxAmmo)
    {
        currentAmmo = newAmmo;
        maxAmmo = newMaxAmmo;
    }
}
