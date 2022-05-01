using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class PlayerBandit : MonoBehaviour, TileMovement
{
    public DamagePopup damagePopup;
    public TurnController turnController;

    public Button attackButton;
    public Transform movePoint;

    public bool isTurn;

    [SerializeField] protected int maxHealthPoints;
    [SerializeField] protected int healthPoints;
    [SerializeField] protected int attackDamage;

    protected float attackRange = 3f;

    private float moveSpeed = 5f;

    private void Start()
    {
        healthPoints = maxHealthPoints;
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
            if (Vector2.Distance(gameObject.transform.position, hit.collider.gameObject.transform.position) < 2.5f)
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
    }
}
