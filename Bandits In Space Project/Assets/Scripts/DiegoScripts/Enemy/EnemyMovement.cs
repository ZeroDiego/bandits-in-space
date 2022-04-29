using UnityEngine;

public class EnemyMovement : MonoBehaviour, TileMovement
{
    public PlayerBandit bandit;
    public TurnController turnController;

    public Transform targetTile;

    public bool isTurn;

    private EnemyHealth enemyHealth;

    private Transform banditTransform;

    private float moveSpeed = 5f;
    private float targetDistance;

    void Start()
    {
        banditTransform = bandit.gameObject.GetComponent<Transform>();
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
        targetDistance = banditTransform.position.x - gameObject.transform.position.x;

        float upOrDown = Random.Range(0, 2);

        if (banditTransform.position.x < gameObject.transform.position.x && targetDistance > 1 || targetDistance < -1)
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
        else if (banditTransform.position.x > gameObject.transform.position.x && targetDistance > 1 || targetDistance < -1)
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
            enemyHealth.DealDamage(bandit);
        }

        if (targetTile.position.y > 1f)
        {
            if (targetTile.position.x > 0)
                targetTile.position = new Vector3(targetTile.position.x + 1.5f, 1f, 0);
            else
                targetTile.position = new Vector3(targetTile.position.x - 1.5f, 1f, 0);
        }
        else if (targetTile.position.y < -1.5f)
        {
            if (targetTile.position.x > 0)
                targetTile.position = new Vector3(targetTile.position.x + 1.5f, -1.25f, 0);
            else
                targetTile.position = new Vector3(targetTile.position.x - 1.5f, -1.25f, 0);
        }
        else if (targetTile.position.Equals(banditTransform.position))
        {
            targetTile.position = transform.position;
        }
    }
}
