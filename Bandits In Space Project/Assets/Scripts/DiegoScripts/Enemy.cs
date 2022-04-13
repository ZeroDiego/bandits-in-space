using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int healthPoints = 20;
    //[SerializeField] private int attackDamage = 10;

    public void TakeDamage(int damage)
    {
        healthPoints -= damage;

        if (healthPoints <= 0)
        {
            Incapacitated();
        }
    }

    private void Incapacitated()
    {
        Destroy(gameObject);
    }
}
