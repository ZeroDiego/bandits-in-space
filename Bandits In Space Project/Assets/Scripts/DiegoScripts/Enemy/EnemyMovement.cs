using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, TileMovement
{
    public PlayerBandit[] bandits;
    public EnemyMovement otherEnemyMovement;
    public TurnController turnController;

    public Transform targetTile;

    public bool isTurn;

    private EnemyHealth enemyHealth;

    private SpriteRenderer spriteRenderer;

    private float moveSpeed = 5f;
    private float targetDistance;

    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        targetTile.parent = null;
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetTile.position, moveSpeed * Time.deltaTime);

        if (isTurn)
        {
            if (Vector3.Distance(transform.position, targetTile.position) <= .05f)
            {
                TileMovement();
                turnController.SetTurn(gameObject.name);
            }
        }
    }

    public void SetPlayerArray(PlayerBandit player)
    {
        int index = 0;

        for (int i = 0; i < bandits.Length; i++)
        {
            if (bandits[i].Equals(player))
            {
                index = i;
            }
        }

        for (int i = index; i < bandits.Length - 1; i++)
        {
            bandits[i] = bandits[i + 1];
        }

        Array.Resize(ref bandits, bandits.Length - 1);
    }

    public void TileMovement()
    {
        PlayerBandit targetPlayer = null;

        if (bandits.Length >= 2)
        {
            for (int i = 0; i < bandits.Length - 1; i++)
            {
                if (Vector3.Distance(bandits[i].transform.position, transform.position) < Vector3.Distance(bandits[i + 1].transform.position, transform.position))
                {
                    targetDistance = Vector3.Distance(bandits[i].transform.position, transform.position);
                    targetPlayer = bandits[i];
                }
                else
                {
                    targetDistance = Vector3.Distance(bandits[i + 1].transform.position, transform.position);
                    targetPlayer = bandits[i + 1];
                }
            }
        }
        else
        {
            targetDistance = Vector3.Distance(bandits[0].transform.position, transform.position);
            targetPlayer = bandits[0];
        }

        if (targetPlayer != null)
        {
            float upOrDown = UnityEngine.Random.Range(0, 2);

            if (targetDistance > 3.0f)
            {
                if (targetPlayer.transform.position.x > transform.position.x)
                {
                    if (upOrDown == 0)
                    {
                        targetTile.position += new Vector3(1.5f, -0.75f, 0);
                    }
                    else
                    {
                        targetTile.position += new Vector3(1.5f, 0.75f, 0);
                    }
                }
                else
                {
                    if (upOrDown == 0)
                    {
                        targetTile.position += new Vector3(-1.5f, -0.75f, 0);
                    }
                    else
                    {
                        targetTile.position += new Vector3(-1.5f, 0.75f, 0);
                    }
                }
            }
            else
            {
                enemyHealth.DealDamage(targetPlayer);
            }

            if (targetTile.position.y > 3.5f)
            {
                targetTile.position = transform.position;
            }

            if (targetTile.position.y < -1.5f)
            {
                targetTile.position = transform.position;
            }

            if (targetTile.position.x < -9.0f)
            {
                targetTile.position = transform.position;
            }

            if (targetTile.position.x > 9.0f)
            {
                targetTile.position = transform.position;
            }

            if (targetTile.position.Equals(targetPlayer.transform.position))
            {
                targetTile.position = transform.position;
            }

            if (otherEnemyMovement != null)
            {
                if (targetTile.position.Equals(otherEnemyMovement.transform.position))
                {
                    targetTile.position = transform.position;
                }
            }
        }
        else
        {
            targetTile.position = transform.position;
        }

        if (targetTile.position.x > transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }
}
