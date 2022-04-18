using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Transform movePoint;

    public Vector3 level1 = new Vector3(-6, 1, 0);
    public Vector3 level2 = new Vector3(6, 1, 0);
    public Vector3 level3 = new Vector3(6, 4, 0);

    public Vector3 whereToGo = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    private void goTo()
    {
        if(whereToGo == level1)
        {
            if(transform.position == level3)
            {
                transform.position = Vector3.MoveTowards(transform.position, level2, moveSpeed * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, level1, moveSpeed * Time.deltaTime);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {


        void OnMouseUpAsButton()
        {
            
        }




        /*
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            }

            if(Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            }
        }

        */





    }







}
