using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public static int numberOfLevelsComplete = 0;
    [SerializeField] private SceneChanger sceneChanger;
    [SerializeField] private AudioSource levelMusic;
    [SerializeField] private AudioSource victoryMusic;
    GameObject pauseMenu;

    private void Awake()
    {
        victoryMusic.enabled = false; 
    }

    private void increaseLevelsComplete()
    {
        if(numberOfLevelsComplete == 0)
        {
            pauseMenu.SetActive(true); 
            //sceneChanger.FadeToLevel(4); 
        }
        numberOfLevelsComplete++;
        gameObject.SetActive(false); 
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if(GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            levelMusic.enabled = false;
            victoryMusic.enabled = true; 
            increaseLevelsComplete();             
        }

    }
}
