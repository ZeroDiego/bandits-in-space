using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerBandit : MonoBehaviour, TileMovement
{
    public EnemyMovement[] enemies;
    public DamagePopup damagePopup;
    public TurnController turnController;

    public Button attackButton;
    public Transform movePoint;

    public bool isTurn;

    [SerializeField] protected int maxHealthPoints;
    [SerializeField] protected int healthPoints;
    [SerializeField] protected int attackDamage;
    [SerializeField] protected HealthBarScript healthBarScript;
    [SerializeField] protected GameObject healthBar;

    protected float attackRange = 3f;

    private float moveSpeed = 5f;
    [SerializeField] private float moveRange = 3f;

    private void Start()
    {
        healthBarScript = healthBar.GetComponent<HealthBarScript>();
        healthPoints = maxHealthPoints;
        healthBarScript.SetMaxHealth(maxHealthPoints);
        healthBarScript.SetNameText(gameObject.name);
        movePoint.parent = null;
        attackButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (isTurn)
        {
            if (Input.GetMouseButtonDown(0))
            {
                TileMovement();
            }
        }

        if (healthPoints <= 0)
        {
            foreach (EnemyMovement enemy in enemies)
            {
                enemy.SetPlayerArray(this);
            }

            turnController.SetPlayerArray(gameObject.name);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (isTurn)
        {
            attackButton.gameObject.SetActive(CheckForEnemy(transform));
        }
    }

    public void SetEnemyArray(EnemyHealth enemy)
    {
        int index = 0;

        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].Equals(enemy))
            {
                index = i;
            }
        }

        for (int i = index; i < enemies.Length - 1; i++)
        {
            enemies[i] = enemies[i + 1];
        }

        Array.Resize(ref enemies, enemies.Length - 1);
    }

    public bool CheckForEnemy(Transform transform)
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, attackRange, 1 << 6);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, -Vector2.left, attackRange, 1 << 6);

        if (hitLeft.collider != null || hitRight.collider != null)
        {
            if (Mathf.Abs(hitLeft.point.x - transform.position.x) <= 3 || Mathf.Abs(hitRight.point.x - transform.position.x) <= 3)
            {
                return true;
            }
        }

        return false;
    }

    abstract public void Attack();

    public void TileMovement()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit && hit.collider.gameObject.CompareTag("Tile"))
        {
            if (Vector2.Distance(gameObject.transform.position, hit.collider.gameObject.transform.position) < moveRange)
            {
                Vector3 tilePosition = hit.collider.gameObject.transform.position;
                tilePosition.y += 0.25f;
                movePoint.position = tilePosition;
                turnController.SetTurn();
            }
        }
    }

    public void TakeDamage(int damageToTake)
    {
        healthPoints -= damageToTake;
        damagePopup.Create(transform.position, damageToTake);
        healthBarScript.SetHealth(healthPoints);
    }
}
