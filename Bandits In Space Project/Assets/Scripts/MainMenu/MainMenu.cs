using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        StartCoroutine(NewGameCoroutine());      
    }

    IEnumerator NewGameCoroutine()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene("Introduction"); // should be changed to specific scenes instead of index
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }   

}
