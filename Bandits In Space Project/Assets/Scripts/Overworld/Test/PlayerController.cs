using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Transform movePoint;
    public Transform lastCheckpoint;
    public Transform levelGoal;

    public GameObject[] levels;

    public int positionSelector;

    public string[] levelName;

    private int lastCheckpointIndex;
    private int levelGoalIndex;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        lastCheckpoint.parent = null;
        levelGoal.parent = null;
        transform.position = levels[positionSelector].transform.position;
        movePoint.position = levels[positionSelector].transform.position;
        lastCheckpoint.position = levels[positionSelector].transform.position;
        levelGoal.position = levels[positionSelector].transform.position;
    }


    void goTo(int indexToGoTo)
    {
        movePoint.position = levels[indexToGoTo].transform.position;
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
                lastCheckpointIndex = var1;
            }
        }
        if (Vector3.Distance(transform.position, levelGoal.position) < 0.1f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit)
                {
                    for (int goalLevel = 0; goalLevel < levels.Length; goalLevel++)
                    {
                        if (hit.transform.position == levels[goalLevel].transform.position)
                        {
                            levelGoal.position = levels[goalLevel].transform.position;
                            levelGoalIndex = goalLevel;
                        }
                    }
                }
            }
        }

        int i = levelGoalIndex - lastCheckpointIndex; //returns the difference between level "steps" i.e level 3 is two steps from level 1, returning 2

        if (i < 0)
        {
            i *= -1; //counts how many steps the player should take, if its -2 that means the player should take 2 steps backwards
        }
        if (levelGoalIndex > lastCheckpointIndex)
        {
            goTo(lastCheckpointIndex + 1);
        }
        else if (levelGoalIndex < lastCheckpointIndex)
        {
            goTo(lastCheckpointIndex - 1);
        }
    }
}
