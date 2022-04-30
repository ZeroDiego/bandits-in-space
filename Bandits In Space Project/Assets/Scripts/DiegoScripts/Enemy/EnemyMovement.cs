using UnityEngine;

public class EnemyMovement : MonoBehaviour, TileMovement
{
    public PlayerBandit[] bandits;
    public EnemyMovement otherEnemyMovement;
    public TurnController turnController;

    public Transform targetTile;

    public bool isTurn;

    private EnemyHealth enemyHealth;

    private float moveSpeed = 5f;
    private float targetDistance;

    void Start()
    {
        enemyHealth = gameObject.GetComponent<EnemyHealth>();
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
                turnController.SetTurn();
            }
        }
    }

    public void TileMovement()
    {
        PlayerBandit targetPlayer = null;

        for (int i = 0; i < bandits.Length - 1; i++)
        {
            if (Vector3.Distance(bandits[i].transform.position, transform.position) > Vector3.Distance(bandits[i + 1].transform.position, transform.position))
            {
                targetDistance = Vector3.Distance(bandits[i].transform.position, transform.position);
                targetPlayer = bandits[i];
            }
            else
            {
                targetDistance = Vector3.Distance(bandits[i + 1].transform.position, transform.position);
                targetPlayer = bandits[i + 1];
            }

            Debug.Log("TargetPlayer: " + targetPlayer);
            Debug.Log("TargetDistance: " + targetDistance);
        }

        float upOrDown = Random.Range(0, 2);

        if (Vector3.Distance(targetPlayer.transform.position, transform.position) > 0 && targetDistance > 0)
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
        else if (Vector3.Distance(targetPlayer.transform.position, transform.position) < 0 && targetDistance > 0)
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
        else if (targetDistance > -1.5f || targetDistance < 1.5f)
        {
            enemyHealth.DealDamage(targetPlayer);
        }

        if (targetTile.position.y > 3.75f)
        {
            if (targetTile.position.x > -9.0f)
                targetTile.position = new Vector3(targetTile.position.x + 1.5f, 3.75f, 0);
            else
                targetTile.position = new Vector3(targetTile.position.x - 1.5f, 3.75f, 0);
        }
        else if (targetTile.position.y < -1.5f)
        {
            if (targetTile.position.x > -9.0f)
                targetTile.position = new Vector3(targetTile.position.x + 1.5f, -1.25f, 0);
            else
                targetTile.position = new Vector3(targetTile.position.x - 1.5f, -1.25f, 0);
        }
        else if (targetTile.position.x < -9.0f)
        {

        }
        
        if (targetTile.position.Equals(targetPlayer.transform.position))
        {
            targetTile.position = transform.position;
        }
        else if (otherEnemyMovement != null)
        {
            if (targetTile.position.Equals(otherEnemyMovement.transform.position))
            {
                targetTile.position = transform.position;
            }
        }
    }
}
