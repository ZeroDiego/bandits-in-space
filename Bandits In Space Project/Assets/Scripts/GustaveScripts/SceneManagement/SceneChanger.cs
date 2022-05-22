using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private FadeController fadeController;
    private bool isChangingScene;
 
    public void ChangeScene()
    {
        Time.timeScale = 1f;
        fadeController.Fade();
        isChangingScene = true; 
    }

    public void ChangeScene(string nameOfScene)
    {
        Time.timeScale = 1f;
        fadeController.Fade();
        isChangingScene = true;
        SceneManager.LoadScene(nameOfScene); 
    }

    private void Update()
    {
        if (fadeController.imageToFade.color.a >= 1 && isChangingScene)
        {
            SceneManager.LoadSceneAsync(gameObject.name);
        } else if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0 && SceneManager.GetActiveScene().name != "Overworld")
        {
            ChangeSceneLevelComplete();
        }

    }

    private void ChangeSceneLevelComplete()
    {
        SceneManager.LoadSceneAsync("Overworld");
    }
}
