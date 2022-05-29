using System;
using UnityEngine;

public class EnemyMovement : Entity, TileMovement
{
    private EnemyHealth enemyHealth;
    [SerializeField] private PlayerBandit[] bandits;
    private SpriteRenderer spriteRenderer;
    private TurnController turnController;
    private Transform targetTile;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private float moveSpeed = 5f;
    private float targetDistance;

    private void Awake()
    {
        Transform[] transforms = GetComponentsInChildren<Transform>();

        foreach (Transform transform in transforms)
        {
            if (transform.parent != null)
            {
                targetTile = transform;
            }
        }

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Array.Resize(ref bandits, players.Length);

        for (int i = 0; i < players.Length; i++)
        {
            bandits[i] = players[i].GetComponent<PlayerBandit>();
        }

        turnController = GameObject.Find("TurnController").GetComponent<TurnController>();
        enemyHealth = GetComponent<EnemyHealth>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        targetTile.SetParent(null);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetTile.position, moveSpeed * Time.deltaTime);

        if (isTurn)
        {
            if (Vector3.Distance(transform.position, targetTile.position) <= .05f)
            {
                TileMovement();
                turnController.SetTurn();
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
                        targetTile.position += new Vector3(1f, -1.1f, 0);
                    }
                    else
                    {
                        targetTile.position += new Vector3(1f, 1.1f, 0);
                    }
                }
                else
                {
                    if (upOrDown == 0)
                    {
                        targetTile.position += new Vector3(-1f, -1.1f, 0);
                    }
                    else
                    {
                        targetTile.position += new Vector3(-1f, 1.1f, 0);
                    }
                }

                if (targetTile.position.y > maxY)
                {
                    targetTile.position = transform.position;
                }

                if (targetTile.position.y < minY)
                {
                    targetTile.position = transform.position;
                }

                if (targetTile.position.x < minX)
                {
                    targetTile.position = transform.position;
                }

                if (targetTile.position.x > maxX)
                {
                    targetTile.position = transform.position;
                }
            }
            else
            {
                enemyHealth.DealDamage(targetPlayer);
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
