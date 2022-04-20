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
        if (collision.CompareTag("Character"))
        {
            collision.gameObject.GetComponent<Bandit>().TakeDamage(hazardDamage); 
        }
    }
   
}
