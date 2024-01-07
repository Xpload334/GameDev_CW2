using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    public bool isLoading;
    public Image fadeImage;
    public float fadeOutDelay = 0.5f;
    public float fadeInDelay = 0.5f;
    public float fadeSpeed = 1f;


    private void Start()
    {
        StartFadeFromBlack();
    }

    public void StartFadeToBlack(UnityAction afterFadeAction)
    {
        if(isLoading) return;
        StartCoroutine(FadeToBlack(afterFadeAction));
    }
    public void StartFadeToBlack()
    {
        StartCoroutine(FadeToBlack(() =>
        {
            Debug.Log("Fade finished");
        }));
    }
    
    public void StartFadeFromBlack(UnityAction afterFadeAction)
    {
        StartCoroutine(FadeFromBlack(afterFadeAction));
    }
    public void StartFadeFromBlack()
    {
        StartCoroutine(FadeFromBlack(() =>
        {
            Debug.Log("Fade finished");
        }));
    }

    private IEnumerator FadeToBlack(UnityAction actionToTrigger)
    {
        isLoading = true;
        fadeImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(fadeOutDelay);
        float alpha = 0;

        while (alpha < 1)
        {
            alpha += Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        // Invoke finishing event
        actionToTrigger?.Invoke();
        isLoading = false;
    }
    
    private IEnumerator FadeFromBlack(UnityAction actionToTrigger)
    {
        isLoading = true;
        fadeImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(fadeInDelay);
        float alpha = 0;

        while (alpha < 1)
        {
            alpha += Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0, 0, 0, 1 - alpha);
            yield return null;
        }

        // Invoke finishing event
        actionToTrigger?.Invoke();
        isLoading = false;
        fadeImage.gameObject.SetActive(false);
    }
}
