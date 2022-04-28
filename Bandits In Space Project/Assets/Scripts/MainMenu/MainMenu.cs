using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1); // should be changed to specific scenes instead of index
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }   

}
