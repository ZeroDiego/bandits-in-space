using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action MovementEvent;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            MovementEvent?.Invoke();
        }
    }
}
