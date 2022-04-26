﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_Mine : Hazard
{

    public int explosionRadius;
    private void Awake()
    {
        hazardDamage = 25;
        isVisible = false;
        hasBeenActivated = false; 
    }

    private void Explode() //Method that makes mine explode if character steps on it
    {

        isVisible = true; 
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
        if (collision.CompareTag("Bandit"))
        {
            collision.gameObject.GetComponent<PlayerBandit>().TakeDamage(DoDamage());
        } else if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(DoDamage());
        }
    }

    
    protected override int DoDamage()
    {
        return hazardDamage; 
    }

    public void ChangeVisibility() //Changes whether trap is visible
    {
        if (this.isVisible)
        {
            this.isVisible = false; 
        }
        else
        {
            this.isVisible = true; 
        }
    }
}

