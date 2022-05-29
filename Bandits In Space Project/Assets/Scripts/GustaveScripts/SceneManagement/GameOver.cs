using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class GameOver : MonoBehaviour
{
    [SerializeField] private AudioSource stageMusicController;
    [SerializeField] private AudioSource gameOverMusicController;

    [SerializeField] private Text gameOverText;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject resumeButton;

    private void Awake()
    {
        gameOverText.gameObject.SetActive(false);
        gameOverMusicController.enabled = false;
    }

    void Update()
    {                
        if(GameObject.FindGameObjectsWithTag("Player").Length <= 0)
        {
            gameOverText.gameObject.SetActive(true);            
            pauseMenu.SetActive(true);
            resumeButton.SetActive(false); 

            stageMusicController.enabled = false;
            gameOverMusicController.enabled = true; 
        }
    }
}
