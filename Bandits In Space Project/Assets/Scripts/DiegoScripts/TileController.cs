using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public Bandit bandit;
    public GameObject[] tiles;
    public SpriteRenderer[] spriteRenderers;

    private Color activeColor = Color.blue;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                TileUnactive();
                TileActive(hit);
            }
            else
            {
                TileUnactive();
            }
        }
    }

    void TileActive(RaycastHit hit)
    {
        if (hit.collider.gameObject.CompareTag("Tile"))
        {
            int tileID = System.Array.IndexOf(tiles, hit.collider.gameObject);
            spriteRenderers[tileID].color = activeColor;
        }
    }

    void TileUnactive()
    {
        foreach (SpriteRenderer spriteRenderer in spriteRenderers)
        {
            if (spriteRenderer.color == Color.blue)
            {
                spriteRenderer.color = new Color32(150, 75, 0, 255);
            }
        }
    }
}
