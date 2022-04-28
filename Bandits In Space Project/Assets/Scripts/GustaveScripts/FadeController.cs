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


    private void Start()
    {
        nonTransparentColor(imageToFade);
    }

    public void Fade()
    {
        isActivated = true;
    }

    public void nonTransparentColor(Image nonTransparent)
    {
        nonTransparent.color = new Color(0, 0, 0, 1);
    }

    public void FadeOut()
    {
        if (imageToFade.color.a <= 1)
        {
            fadeTime = imageToFade.color.a + (fadeSpeed * Time.deltaTime);
            imageToFade.color = new Color(0, 0, 0, fadeTime);
        }
    }

    public void FadeIn()
    {
        if (imageToFade.color.a > 0)
        {
            fadeTime = imageToFade.color.a - (fadeSpeed * Time.deltaTime);
            imageToFade.color = new Color(0, 0, 0, fadeTime);
        }
    }

    private void Update()
    {
        if (isActivated)
        {
            FadeOut();
        }
        else if (!isActivated)
        {
            FadeIn();
        }
    }

}


