using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action MovementEvent;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MovementEvent?.Invoke();
        }
    }
}
