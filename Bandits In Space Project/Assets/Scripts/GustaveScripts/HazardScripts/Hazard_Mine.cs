using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_Mine : Hazard
{
    public int explosionRadius;
    [SerializeField] private GameObject mineExplosionSound; 
    private void Awake()
    {
        isVisible = true;
        hasBeenActivated = false; 
    }

    private void Explode() //Method that makes mine explode if character steps on it
    {
        mineExplosionSound.GetComponent<AudioSource>().Play(); 
        isVisible = true; 
        hasBeenActivated = true;    
    }

    private void Update()
    {
        if (hasBeenActivated)
        {
            //Destroy(gameObject);
            Debug.Log(gameObject.name + " has been exploded");
            gameObject.SetActive(false);
        }

        if (!isVisible)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false; 
        } else if (isVisible)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {     
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("XD");
            collision.gameObject.GetComponent<PlayerBandit>().TakeDamage(DoDamage());
            Explode();
        } else 
        {
            //Debug.Log("KKKKALAKA"); 
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(DoDamage());
            Explode();
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

