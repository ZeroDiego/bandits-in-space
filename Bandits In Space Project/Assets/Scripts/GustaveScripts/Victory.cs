using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    private static int numberOfLevelsComplete = 0; 

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if(GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
            if(scene.name != "Overworld" && 
               scene.name != "MainMenu" &&
               scene.name != "Introduction" && 
               scene.name != "Credits")
            {
                numberOfLevelsComplete++; 
            }
    }
}
