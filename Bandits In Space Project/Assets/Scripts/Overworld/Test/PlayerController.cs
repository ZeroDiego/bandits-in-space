using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Transform movePoint;
    public GameObject[] levels;

    public Transform lastCheckpoint;

    public int positionSelector;

    public string[] levelName;

    private bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        lastCheckpoint.parent = null;
        transform.position = levels[positionSelector].transform.position;
        movePoint.position = levels[positionSelector].transform.position;
        lastCheckpoint.position = levels[positionSelector].transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        for(int var1 = 0; var1 < levels.Length; var1++) //checks where the player last landed on a level for reference later
        {
            if(transform.position == levels[var1].transform.position)
            {
                lastCheckpoint.position = levels[var1].transform.position;
            }
        }

        void goTo(int indexToGoTo)
        {
                movePoint.position = levels[indexToGoTo].transform.position;    
        }


        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit)
            {
                for(int var2=0; var2 < levels.Length; var2++)
                {
                    if(lastCheckpoint.position == levels[var2].transform.position)
                    {
                        for(int var3=0; var3 < levels.Length; var3++)
                        {
                            if(hit.transform.position == levels[var3].transform.position)
                            {
                                //Debug.Log(var3 - var2); 
                                int i = var3 - var2; //returns the difference between level "steps" i.e level 3 is two steps from level 1, returning 2

                                if (i > 0) { // if targeted level is lower
                                    for (int methodRuns = 0; methodRuns <= i; methodRuns++) {
                                        goTo(var2+1); // go to the level after this one for methodRuns number of times
                                    }
                                } else if (i < 0) // if targeted level is higher
                                {
                                    for (int methodRuns = 0; methodRuns <= i*-1; methodRuns++)
                                    {
                                        goTo(var2 - 1); // go to the level after this one for methodRuns number of times
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
