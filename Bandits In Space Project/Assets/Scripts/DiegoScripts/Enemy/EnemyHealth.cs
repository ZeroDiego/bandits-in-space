using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public PlayerBandit[] players;
    public TurnController turnController;
    public DamagePopup damagePopup;
    [SerializeField] private AudioSource hitSound; 

    [SerializeField] private int healthPoints = 20;
    [SerializeField] private int attackDamage = 10;

    public void TakeDamage(int damage)
    {
        healthPoints -= damage;
        damagePopup.Create(transform.position, damage);
    }

    private void Update()
    {
        if (healthPoints <= 0)
        {
            Incapacitated();
        }
    }

    public void DealDamage(PlayerBandit bandit)
    {
        hitSound.Play();
        bandit.TakeDamage(attackDamage);
    }

    private void Incapacitated()
    {
        foreach (PlayerBandit player in players)
        {
            player.SetEnemyArray(this);
        }

        turnController.SetEnemyArray(gameObject.name);
        Destroy(gameObject);
    }
}
