using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    
    public void Pause()
    {
        StartCoroutine(PauseCoroutine());
    }

    public IEnumerator PauseCoroutine()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Home(int sceneId)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneId);
    }

    public void Restart(int sceneId)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneId);
    }
}
