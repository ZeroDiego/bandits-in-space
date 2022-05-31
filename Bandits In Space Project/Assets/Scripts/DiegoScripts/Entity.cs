using UnityEngine;

public class Entity : MonoBehaviour
{
    public bool isTurn;
    public float agility;

    public Entity CompareEntities(Entity otherEntity)
    {
        if (agility > otherEntity.agility)
        {
            return this;
        }
        else
        {
            return otherEntity;
        }
    }
}
