using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    [SerializeField] private Animator buttonAnimator;

    public void animateButton()
    {  
        StartCoroutine(buttonCoroutine()); 
    }

    private IEnumerator buttonCoroutine()
    {
        buttonAnimator.Play("ButtonAnimation");
        yield return new WaitForSecondsRealtime(0.4f);

        if (gameObject.name == "OptionsButton")
        {           
            mainMenu.SetActive(false);
            optionsMenu.SetActive(true);
        } else if(gameObject.name == "QuitButton")
        {
            Debug.Log("quit");
            Application.Quit(); 
        } else if(gameObject.name == "Overworld")
        {
            gameObject.GetComponent<SceneChanger>().FadeToLevel(2); 
        } else if(gameObject.name == "BackButton")
        {
            mainMenu.SetActive(true);
            optionsMenu.SetActive(false); 
        } else if(gameObject.name == "NewGameButton")
        {
            //gameObject.GetComponent<SceneChanger>().FadeToLevel(1); 
        }
    }

}
