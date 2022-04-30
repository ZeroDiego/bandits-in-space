using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutBandit : PlayerBandit
{
    public override void Attack(Transform transform)
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, 4, 1 << 6);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, -Vector2.left, 4, 1 << 6);

        if (hitLeft.collider != null)
        {
            if (hitLeft.collider.gameObject.CompareTag("Enemy"))
            {
                if (hitLeft.collider.gameObject.GetComponent<SpriteRenderer>().flipX)
                {
                    hitLeft.transform.GetComponent<EnemyHealth>().TakeDamage(attackDamage *= 2);
                }
                else
                {
                    hitLeft.transform.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
                }
            }
        }
        else if (hitRight.collider != null)
        {
            if (hitRight.collider.gameObject.CompareTag("Enemy"))
            {
                if (!hitRight.collider.gameObject.GetComponent<SpriteRenderer>().flipX)
                {
                    hitRight.transform.GetComponent<EnemyHealth>().TakeDamage(attackDamage *= 2);
                }
                else
                {
                    hitRight.transform.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
                }
            }
        }

        turnController.SetTurn();
    }
}
