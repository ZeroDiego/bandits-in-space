using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameOver : MonoBehaviour
{
    public PlayerBandit[] playerBandits;
    public bool[] arePlayerBanditsDead;
    int numberOfBanditsDead;

    private void Awake()
    {
        numberOfBanditsDead = 0;
    }
    void Update()
    {      
        /*for(int i = 0; i < playerBandits.Length; i++)
        {
            if (playerBandits[i].getHealthPoints() <= 0)
            {
                arePlayerBanditsDead[i] = true; 
            }
        }
        
        for(int i = 0; i < arePlayerBanditsDead.Length; i++)
        {
            if(arePlayerBanditsDead[i] == true)
            {
                numberOfBanditsDead++; 
            } 

            if(numberOfBanditsDead == arePlayerBanditsDead.Length)
            {
                SceneManager.LoadScene("MainMenu"); 
            }
        }
             */      
        
        if(GameObject.FindGameObjectsWithTag("Player").Length <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
