using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public PlayerBandit bandit;

    public TileTrigger[] tileTriggers;

    private Color activeColor = Color.blue;

    private void Update()
    {
        for (int i = 0; i < tileTriggers.Length; i++)
        {
            if (tileTriggers[i].isActive)
            {
                TileActive(i);
            }
            else
            {
                TileUnactive(i);
            }
        }
    }

    void TileActive(int index)
    {
        tileTriggers[index].GetComponent<SpriteRenderer>().color = activeColor;
    }

    void TileUnactive(int index)
    {
        tileTriggers[index].GetComponent<SpriteRenderer>().color = new Color32(150, 75, 0, 255);
    }
}
