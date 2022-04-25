using UnityEngine;

public class EnemyMovement : MonoBehaviour, TileMovement
{
    public PlayerBandit bandit;
    public TurnController turnController;

    public Transform targetTile;
    public Transform movePointUp;
    public Transform movePointDown;

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
        if (isTurn)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetTile.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetTile.position) <= .05f)
                TileMovement();
        }
    }

    public void TileMovement()
    {
        targetDistance = banditTransform.position.x - gameObject.transform.position.x;

        if (banditTransform.position.x < gameObject.transform.position.x && targetDistance > 1 || targetDistance < -1)
        {
            movePointUp.parent = null;
            movePointDown.parent = null;
            float upOrDown = Random.Range(0, 1);

            if (upOrDown == 0)
                targetTile.position = movePointDown.position;
            else
                targetTile.position = movePointUp.position;    

            if (gameObject.transform.position.Equals(targetTile.position))
            {
                turnController.setEnemyTurn(false);
                movePointUp.parent = gameObject.transform;
                Vector3 tempUp = new Vector3(-1.5f, 1f, 0);
                movePointUp.transform.position += tempUp;
                movePointDown.parent = gameObject.transform;
                Vector3 tempDown = new Vector3(-1.5f, -1f, 0);
                movePointDown.transform.position += tempDown;
            }
        }
        else
        {
            enemyHealth.DealDamage(bandit);
            turnController.setEnemyTurn(false);
        }
    }
}
