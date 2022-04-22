using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{

    private float fadeSpeed = 2.3f; 
    [SerializeField] private bool isActivated;
    public Image imageToFade;

    public void Fade()
    {
        isActivated = true;
    }

    private void Update()
    {
        if (isActivated)
        {
            
            float fadeTime = imageToFade.color.a + (fadeSpeed * Time.deltaTime);
            Debug.Log(fadeTime);
            imageToFade.color = new Color(0, 0, 0, fadeTime);          
        }        
    }

}


