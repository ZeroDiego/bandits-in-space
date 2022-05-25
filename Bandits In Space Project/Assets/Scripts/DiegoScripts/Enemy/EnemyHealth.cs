using System;
using UnityEngine;

public class EnemyHealth : Entity
{
    public DamagePopup damagePopup;
    [SerializeField] private AudioSource hitSound; 

    private PlayerBandit[] bandits;
    private TurnController turnController;

    [SerializeField] private int healthPoints = 20;
    [SerializeField] private int attackDamage = 10;

    private void Awake()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Array.Resize(ref bandits, players.Length);

        for (int i = 0; i < players.Length; i++)
        {
            bandits[i] = players[i].GetComponent<PlayerBandit>();
        }

        turnController = GameObject.Find("TurnController").GetComponent<TurnController>();
    }

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
        foreach (PlayerBandit player in bandits)
        {
            player.SetEnemyArray(this);
        }

        turnController.SetArray(this);
        Destroy(gameObject);
    }
}
