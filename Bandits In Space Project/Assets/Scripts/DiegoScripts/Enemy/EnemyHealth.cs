using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public DamagePopup damagePopup;

    [SerializeField] private int healthPoints = 20;
    [SerializeField] private int attackDamage = 10;

    public void TakeDamage(int damage)
    {
        healthPoints -= damage;
        damagePopup.Create(transform.position, damage);

        if (healthPoints <= 0)
        {
            Incapacitated();
        }
    }

    private void Update()
    {
        if(healthPoints <= 0)
        {
            Incapacitated();
        }
    }

    public void DealDamage(PlayerBandit bandit)
    {
        bandit.setHealthPoints(bandit.getHealthPoints() - attackDamage);
    }

    private void Incapacitated()
    {
        Destroy(gameObject);
    }
}
