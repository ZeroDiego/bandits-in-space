using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private FadeController fadeController;
    private bool isChangingScene;
    public bool areEnemiesDead; 
    public void ChangeScene()
    {
        fadeController.Fade();
        isChangingScene = true;       
    }
    private void Update()
    {
        if (fadeController.imageToFade.color.a >= 1 && isChangingScene && areEnemiesDead)
        {
            SceneManager.LoadSceneAsync(gameObject.name);
        }
    }

}
