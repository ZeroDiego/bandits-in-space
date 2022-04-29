using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test : MonoBehaviour
{

    public DamagePopup damagePopup;

    private void Start()
    {

        //damagePopup.Create(Vector3.zero, 300);
    }


    private void Update()
    {
        Vector3 worldPositionWithZ = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 worldPosition = new Vector3(worldPositionWithZ.x, worldPositionWithZ.y);
        if (Input.GetMouseButtonDown(0))
        {
            damagePopup.Create(worldPosition, 100);
        }

    }

}
