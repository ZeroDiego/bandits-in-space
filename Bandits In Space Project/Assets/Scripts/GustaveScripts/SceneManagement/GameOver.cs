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
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject resumeButton;
    private FadeController fade = new FadeController();

    private void Awake()
    {
        gameOverText.gameObject.SetActive(false); 
    }
    void Update()
    {                
        if(GameObject.FindGameObjectsWithTag("Player").Length <= 0)
        {
            gameOverText.gameObject.SetActive(true);            
            pauseMenu.SetActive(true);
            resumeButton.SetActive(false); 

            Time.timeScale = 0.4f; 
            stageMusicController.SetActive(false);
            gameOverMusicController.SetActive(true); 
        }
    }
}
