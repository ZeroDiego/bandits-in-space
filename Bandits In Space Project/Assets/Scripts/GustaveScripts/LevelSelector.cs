using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private GameObject sceneChangerObject;
    [SerializeField] private GameObject buttonText; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            sceneChangerObject.name = this.name;
            buttonText.GetComponent<TextMeshProUGUI>().SetText(this.name); 
        }
    }
}
