using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    public GameObject[,] tileArray;  
    public GameObject tilePrefab;

    public Vector3 leftBottomLocation = new Vector3(0, 0, 0);

    public int rows = 10;
    public int coloums = 10;
    public float scale = 1;


    private void Awake()
    {
        tileArray = new GameObject[coloums, rows];

        if (tilePrefab)
            GenerateGrid();
        else
            Debug.Log("Missing Prefab");
    }

    private void GenerateGrid()
    {
        int offset = 0;

        for (int i = 0; i < coloums; i++)
        {
            offset++;

            for (int j = 0; j < rows; j++)
            {
                if (j % 2 == 0)
                {
                    GameObject tile = Instantiate(tilePrefab, new Vector2(leftBottomLocation.x + scale * i + offset,
                        leftBottomLocation.y + scale * j), Quaternion.identity);

                    tile.transform.SetParent(gameObject.transform);
                    tile.GetComponent<GridStats>().x = i;
                    tile.GetComponent<GridStats>().y = j;
                    tileArray[i, j] = tile;
                }
                else
                {
                    GameObject tile = Instantiate(tilePrefab, new Vector2(leftBottomLocation.x + scale * i + offset + scale,
                        leftBottomLocation.y + scale * j), Quaternion.identity);

                    tile.transform.SetParent(gameObject.transform);
                    tile.GetComponent<GridStats>().x = i;
                    tile.GetComponent<GridStats>().y = j;
                    tileArray[i, j] = tile;
                }
            }
        }
    }
}
