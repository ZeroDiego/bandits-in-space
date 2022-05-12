using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject stageMusicController;
    [SerializeField] private GameObject victoryMusicController;
    [SerializeField] private GameObject gameOverMusicController;
    [SerializeField] private Text gameOverText; 

    private void Awake()
    {
        gameOverText.gameObject.SetActive(false); 
    }
    void Update()
    {                
        if(GameObject.FindGameObjectsWithTag("Player").Length <= 0)
        {
            gameOverText.gameObject.SetActive(true);
            gameOverText.gameObject.transform.position = new Vector2(0, -1 * Time.deltaTime);
            Time.timeScale = 0.4f; 
            stageMusicController.SetActive(false);
            gameOverMusicController.SetActive(true); 
        }
    }
}
