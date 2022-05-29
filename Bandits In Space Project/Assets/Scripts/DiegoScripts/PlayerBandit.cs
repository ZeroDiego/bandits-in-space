using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerBandit : Entity, TileMovement
{   
    public DamagePopup damagePopup;
    
    [SerializeField] protected AudioSource hitSound; 

    public Button attackButton;
    public Transform movePoint;

    [SerializeField] protected int maxHealthPoints;
    [SerializeField] protected int healthPoints;
    [SerializeField] protected int attackDamage;
    [SerializeField] protected HealthBarScript healthBarScript;
    [SerializeField] protected GameObject healthBar;
    [SerializeField] protected ParticleSystem attackParticleSystem;
    protected TurnController turnController;

    [SerializeField] private EnemyMovement[] enemyMovements;
    private TileController tileController;

    protected float attackRange = 3f;

    private float moveSpeed = 5f;
    [SerializeField] private float moveRange = 3f;

    private void Awake()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Array.Resize(ref enemyMovements, enemies.Length);

        for (int i = 0; i < enemies.Length; i++)
        {
            enemyMovements[i] = enemies[i].GetComponent<EnemyMovement>();
        }

        turnController = GameObject.Find("TurnController").GetComponent<TurnController>();
        tileController = GameObject.Find("TileController").GetComponent<TileController>();
    }

    private void Start()
    {
        healthBarScript = healthBar.GetComponent<HealthBarScript>();
        healthPoints = maxHealthPoints;
        healthBarScript.SetMaxHealth(maxHealthPoints);
        healthBarScript.SetNameText(gameObject.name);
        movePoint.parent = null;
        attackButton.gameObject.SetActive(false);
        attackParticleSystem.gameObject.SetActive(false);
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

            for (int i = 0; i < tileController.tileTriggers.Length; i++)
            {
                if (Vector2.Distance(gameObject.transform.position, tileController.movementParticleSystems[i].gameObject.transform.position) < moveRange 
                    && !tileController.tileTriggers[i].isActive)
                {
                    tileController.movementParticleSystems[i].gameObject.SetActive(true);
                    tileController.movementParticleSystems[i].Play();
                }
                else
                {
                    tileController.movementParticleSystems[i].gameObject.SetActive(false);
                    tileController.movementParticleSystems[i].Clear();
                }
            }
        }
        else
        {
            foreach (EnemyMovement enemy in enemyMovements)
            {
                if (enemy.isTurn)
                {
                    foreach(ParticleSystem movementParticleSystem in tileController.movementParticleSystems)
                    {
                        movementParticleSystem.gameObject.SetActive(false);
                        movementParticleSystem.Clear();
                    }
                }
            }
        } 

        if (healthPoints <= 0)
        {
            foreach (EnemyMovement enemy in enemyMovements)
            {
                enemy.SetPlayerArray(this);
            }

            turnController.SetArray(this);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (isTurn)
        {
            if(CheckForEnemyLeft(transform) || CheckForEnemyRight(transform))
            {
                Debug.Log("Hej"); 
                attackButton.gameObject.SetActive(true);
                attackParticleSystem.gameObject.SetActive(true);
            }
            //attackButton.gameObject.SetActive(CheckForEnemyLeft(transform) || CheckForEnemyRight(transform));
            //attackParticleSystem.gameObject.SetActive(CheckForEnemyLeft(transform) || CheckForEnemyRight(transform));

            ParticleSystem.ShapeModule shapeSettings = attackParticleSystem.GetComponent<ParticleSystem>().shape;
            ParticleSystemRenderer renderSettings = attackParticleSystem.GetComponent<ParticleSystemRenderer>();

            if (CheckForEnemyLeft(transform))
            {
                shapeSettings.position = new Vector3(-1.75f, 0, 0);
                renderSettings.flip = new Vector3(1, 0, 0);
            }
            else if (CheckForEnemyRight(transform))
            {
                shapeSettings.position = new Vector3(0.75f, 0, 0);
                renderSettings.flip = new Vector3(0, 0, 0);
            }
        }
    }

    public void SetEnemyArray(EnemyHealth enemy)
    {
        int index = 0;

        for (int i = 0; i < enemyMovements.Length; i++)
        {
            if (enemyMovements[i].Equals(enemy))
            {
                index = i;
            }
        }

        for (int i = index; i < enemyMovements.Length - 1; i++)
        {
            enemyMovements[i] = enemyMovements[i + 1];
        }

        Array.Resize(ref enemyMovements, enemyMovements.Length - 1);
    }

    public bool CheckForEnemyLeft(Transform transform)
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, new Vector2(-3, 0), attackRange, 1 << 6);

        if (hitLeft.collider != null)
        {
            if (Mathf.Abs(hitLeft.point.x - transform.position.x) <= 3)
            {
                return true;
            }
        }

        return false;
    }

    public bool CheckForEnemyRight(Transform transform)
    {
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, new Vector2(3, 0), attackRange, 1 << 6);

        if (hitRight.collider != null)
        {
            if (Mathf.Abs(hitRight.point.x - transform.position.x) <= 3)
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
            if (Vector2.Distance(gameObject.transform.position, hit.collider.gameObject.transform.position) < moveRange && !hit.collider.gameObject.GetComponent<TileTrigger>().isActive)
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
