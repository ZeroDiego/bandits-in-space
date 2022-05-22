using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{

    private float fadeSpeed = 1.25f;
    [SerializeField] private bool isActivated = false;
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


