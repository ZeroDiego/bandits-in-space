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
        yield return new WaitForSecondsRealtime(0.3f);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

}
