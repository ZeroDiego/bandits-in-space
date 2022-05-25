using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private int levelToLoad; 
    public Animator animator; 

    private void Start()
    {
        if(gameObject.name == "TimeLimiter")
        {
            StartCoroutine(timeBasedChangeScene());
        }
    }

    private IEnumerator timeBasedChangeScene()
    {
        yield return new WaitForSecondsRealtime(20);
        SceneManager.LoadSceneAsync("MainMenu"); 
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex; 
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad); 
    }

}
