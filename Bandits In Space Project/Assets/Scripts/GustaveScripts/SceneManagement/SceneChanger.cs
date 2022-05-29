using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int levelToLoad; 
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

    public void changeSceneFromOverworld()
    {
        if(gameObject.name == "Level 1")
        {
            FadeToLevel(3); 
        } else if(gameObject.name == "Level 2"){
            FadeToLevel(5); 
        } else if(gameObject.name == "Level 3")
        {
            FadeToLevel(7); 
        }
    }

    private void Update()
    {
        //Debug.Log(Victory.numberOfLevelsComplete);
        if(Victory.numberOfLevelsComplete == 3)
        {
            FadeToLevel(5); 
        }
    }

}
