using UnityEngine;
using UnityEngine.UI;

public abstract class Bandit : MonoBehaviour
{
    public Image avatar;
    public Button attackButton;

    [SerializeField] protected int healthPoints;
    [SerializeField] protected int attackDamage;

    private void FixedUpdate()
    {
        attackButton.interactable = CheckForEnemy(transform);
    }

    public bool CheckForEnemy(Transform transform)
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, 1, 1 << 6);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, -Vector2.left, 1, 1 << 6);

        if (hitLeft.collider != null || hitRight.collider != null)
        {
            if (Mathf.Abs(hitLeft.point.x - transform.position.x) <= 1 || Mathf.Abs(hitRight.point.x - transform.position.x) <= 1)
            {
                return true;
            }
        }

        return false;
    }

    abstract public void Attack(Transform transform);
}
