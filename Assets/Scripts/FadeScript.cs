using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    [SerializeField] Image fadeImage;
    [SerializeField] float fadeSpeed;
    float alphaValue;
    bool fadingIn;
    bool fadingOut;

    private void Start()
    {
        FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        if(fadingIn)
        {
            if(fadeImage.color.a > 0)
            {
                alphaValue -= fadeSpeed * Time.deltaTime;
                fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alphaValue);
            }
            else
            {
                fadingIn = false;
                fadeImage.gameObject.SetActive(false);
            }
        } 
        else if (fadingOut)
        {
            if (fadeImage.color.a < 1)
            {
                alphaValue += fadeSpeed * Time.deltaTime;
                fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alphaValue);
            }
            else
            {
                fadingOut = false;
            }
        }
    }

    void FadeIn()
    {
        alphaValue = 1;
        fadingIn = true;
    }

    public void FadeOut()
    {
        fadeImage.gameObject.SetActive(true);
        fadingOut = true;
    }
}
