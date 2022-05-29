using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private GameObject sceneChangerObject;
    [SerializeField] private GameObject buttonText;
    [SerializeField] private GameObject sceneChanger;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if (Victory.numberOfLevelsComplete == 0)
        {
            sceneChangerObject.name = "Level 1";
            buttonText.GetComponent<TextMeshProUGUI>().SetText("Level 1");
            sceneChanger.name = "Level 1";
        }
        else if (Victory.numberOfLevelsComplete == 1)
        {
            sceneChangerObject.name = "Level 2";
            buttonText.GetComponent<TextMeshProUGUI>().SetText("Level 2");
            sceneChanger.name = "Level 2";
        } else if (Victory.numberOfLevelsComplete == 2)
        {
            sceneChangerObject.name = "Level 3";
            buttonText.GetComponent<TextMeshProUGUI>().SetText("Level 3");
            sceneChanger.name = "Level 3";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.gameObject.name == "Player")
        {
            sceneChangerObject.name = this.name;
            
            sceneChanger.name = this.name; 
        }*/
    }
}
