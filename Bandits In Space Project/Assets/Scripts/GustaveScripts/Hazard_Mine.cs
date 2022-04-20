using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_Mine : Hazard
{
    private void Awake()
    {
        hazardDamage = 2;
        isVisible = false;
        hasBeenActivated = false; 
    }

    private void Explode() //method that makes mine explode if character steps on it
    {
     
            //explode
            hasBeenActivated = true;
        
    }

    private void Update()
    {
        if (hasBeenActivated)
        {
            Destroy(this);
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Explode();
    }

}
