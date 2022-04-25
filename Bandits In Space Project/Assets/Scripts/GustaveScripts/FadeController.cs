using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{

    private float fadeSpeed = 2.3f; 
    [SerializeField] private bool isActivated;
    public Image imageToFade;
    private float fadeTime;

    public void Fade()
    {
        isActivated = true;
    }

    private void Awake()
    {
        imageToFade.color = new Color(0, 0, 0, 1);
        
    }

    private void Update()
    {
        if (isActivated)
        {
            
            fadeTime = imageToFade.color.a + (fadeSpeed * Time.deltaTime);
            imageToFade.color = new Color(0, 0, 0, fadeTime);          
        } else if( imageToFade.color.a > 0 )
        {
            fadeTime = imageToFade.color.a - ((fadeSpeed - 1f) * Time.deltaTime);
            imageToFade.color = new Color(0, 0, 0, fadeTime);
        }       
    }

}


