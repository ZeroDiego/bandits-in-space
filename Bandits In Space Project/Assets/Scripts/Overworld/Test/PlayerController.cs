using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Transform movePoint;
    public Transform lastCheckpoint;
    public Transform goalLevel;

    public GameObject[] levels;

    public int positionSelector;

    public string[] levelName;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        lastCheckpoint.parent = null;
        transform.position = levels[positionSelector].transform.position;
        movePoint.position = levels[positionSelector].transform.position;
        lastCheckpoint.position = levels[positionSelector].transform.position;
        goalLevel.parent = null;

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        for (int var1 = 0; var1 < levels.Length; var1++) //checks where the player last landed on a level for reference later
        {
            if (transform.position == levels[var1].transform.position)
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
                for (int currentPositionLevel = 0; currentPositionLevel < levels.Length; currentPositionLevel++)
                {
                    if (lastCheckpoint.position == levels[currentPositionLevel].transform.position)
                    {
                        for (int goalLevel = 0; goalLevel < levels.Length; goalLevel++)
                        {
                            if (hit.transform.position == levels[goalLevel].transform.position)
                            {
                                Debug.Log(goalLevel - currentPositionLevel);
                                int i = goalLevel - currentPositionLevel; //returns the difference between level "steps" i.e level 3 is two steps from level 1, returning 2
                                if (i < 0)
                                {
                                    i *= -1;
                                }
                                if (goalLevel > currentPositionLevel)
                                {
                                    Debug.Log("Steps: " + i);
                                    goTo(currentPositionLevel + 1);
                                }
                                else if (goalLevel < currentPositionLevel)
                                {
                                    Debug.Log("Steps: " + i);
                                    goTo(currentPositionLevel - 1);
                                }
                            }
                        }
                    }
                }
            }
        }









    }
}
