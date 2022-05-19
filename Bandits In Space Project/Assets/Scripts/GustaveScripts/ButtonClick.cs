using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] private Animator buttonAnimator;

    public void animateButton()
    {
        StartCoroutine(buttonCoroutine());
    }

    private IEnumerator buttonCoroutine()
    {
        buttonAnimator.Play("ButtonAnimation"); 
        yield return new WaitForSecondsRealtime(0.3f);
    }

}
