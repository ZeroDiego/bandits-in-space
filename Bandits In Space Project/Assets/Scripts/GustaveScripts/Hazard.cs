using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{

    [SerializeField] protected int hazardDamage;
    protected bool hasBeenActivated;
    protected bool isVisible; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bandit"))
        {
            collision.gameObject.GetComponent<Bandit>().TakeDamage(hazardDamage); 
        } else if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(hazardDamage);
        }
    }
   
}
