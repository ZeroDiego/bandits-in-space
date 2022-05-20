using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_Mine : Hazard
{
    [SerializeField] private GameObject cameraShaker; 
    [SerializeField] private GameObject mineExplosionSound;
    [SerializeField] private ParticleSystem particles; 
    private void Awake()
    {
        particles.gameObject.SetActive(false); 
        isVisible = true;
        hasBeenActivated = false; 
    }

    private void Explode() //Method that makes mine explode if character steps on it
    {
        mineExplosionSound.GetComponent<AudioSource>().Play();
        particles.gameObject.SetActive(true);
        StartCoroutine(cameraShaker.GetComponent<CameraShake>().Shake()); 
        isVisible = true; 
        hasBeenActivated = true;    
    }

    private void Update()
    {
        if (hasBeenActivated)
        {
            Destroy(gameObject);
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
            collision.gameObject.GetComponent<PlayerBandit>().TakeDamage(DoDamage());
            Explode();
        } else 
        {
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

