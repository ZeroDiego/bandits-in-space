using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class Bandit : MonoBehaviour, TileMovement
{
    public Image avatar;
    public Button attackButton;

    public float moveSpeed = 5f;
    public Transform movePoint;

    [SerializeField] protected int healthPoints;
    [SerializeField] protected int attackDamage;

    private void Start()
    {
        EventManager.MovementEvent += TileMovement;
        movePoint.parent = null;    
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        attackButton.interactable = CheckForEnemy(transform);
    }

    public bool CheckForEnemy(Transform transform)
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, 3, 1 << 6);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, -Vector2.left, 3, 1 << 6);

        if (hitLeft.collider != null || hitRight.collider != null)
        {
            if (Mathf.Abs(hitLeft.point.x - transform.position.x) <= 3 || Mathf.Abs(hitRight.point.x - transform.position.x) <= 3)
            {
                return true;
            }
        }

        return false;
    }

    abstract public void Attack(Transform transform);

    public void TileMovement()
    {
        if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Tile"))
                {
                    Touch touch = Input.GetTouch(0);
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    touchPosition.z = 0;
                    Vector3 tilePosition = hit.collider.gameObject.transform.position;
                    tilePosition.y += 0.5f;
                    movePoint.position = tilePosition;
                }
            }
        }
    }

    private void OnDisable()
    {
        EventManager.MovementEvent -= TileMovement;
    }

    public void TakeDamage( int damageToTake )
    {
        healthPoints -= damageToTake; 
    }

}
