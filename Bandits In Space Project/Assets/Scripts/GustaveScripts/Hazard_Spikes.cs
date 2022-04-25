using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_Spikes : Hazard
{
    private void Awake()
    {
        hazardDamage = 1;
        isVisible = true;
        hasBeenActivated = false; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
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
}
