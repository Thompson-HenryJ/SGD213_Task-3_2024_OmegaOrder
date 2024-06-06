using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoDisplay : MonoBehaviour
{
   
    int currentAmmo;
    int maxAmmo;
    int currentClip;
    int maxClip;
    public TMP_Text clipValue;
    public TMP_Text ammoValue;

    void Start()
    {

    }

    private void Update()
    {
        clipValue.SetText(currentClip.ToString() + "|" + maxClip.ToString());
        ammoValue.SetText(currentAmmo.ToString() + "|" + maxAmmo.ToString());
        
    }

    public void UpdateAmmo(int newAmmo, int newMaxAmmo, int newClip, int newMaxClip)
    {
        currentAmmo = newAmmo;
        maxAmmo = newMaxAmmo;
        currentClip = newClip;
        maxClip = newMaxClip;
    }
}
