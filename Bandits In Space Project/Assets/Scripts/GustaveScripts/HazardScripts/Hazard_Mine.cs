using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_Mine : Hazard
{
    private CameraShake cameraShaker; 
    private AudioSource mineExplosionSound;
    private ParticleSystem particles; 

    private void Awake()
    {
        particles = GetComponentInChildren<ParticleSystem>();
        particles.gameObject.transform.parent = null;
        particles.gameObject.SetActive(false);

        mineExplosionSound = GetComponentInChildren<AudioSource>();
        mineExplosionSound.gameObject.transform.parent = null;

        cameraShaker = GameObject.Find("Main Camera").GetComponent<CameraShake>();

        isVisible = true;
        hasBeenActivated = false; 
    }

    private void Explode() //Method that makes mine explode if character steps on it
    {
        mineExplosionSound.Play();
        particles.gameObject.SetActive(true);
        StartCoroutine(cameraShaker.Shake(1f, .4f));
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

