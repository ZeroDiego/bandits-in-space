using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public static int numberOfLevelsComplete = 0;
    [SerializeField] private SceneChanger sceneChanger; 

    private void increaseLevelsComplete()
    {
        numberOfLevelsComplete++;
        gameObject.SetActive(false); 
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if(GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            sceneChanger.FadeToLevel(2);
            increaseLevelsComplete();             
        }
    }
}
