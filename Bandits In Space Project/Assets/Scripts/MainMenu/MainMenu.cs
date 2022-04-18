using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // should be changed to specific scenes instead of index
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }   

}
