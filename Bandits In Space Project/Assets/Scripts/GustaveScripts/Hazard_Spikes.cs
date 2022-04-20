using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_Spikes : Hazard
{
    private void Awake()
    {
        hazardDamage = 1;
        isVisible = false;
        hasBeenActivated = false; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isVisible = true;
    }
}
