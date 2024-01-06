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
    
    public void StartFadeToBlack(UnityAction afterFadeAction)
    {
        StartCoroutine(FadeToBlack(afterFadeAction));
    }
    
    public void StartFadeFromBlack(UnityAction afterFadeAction)
    {
        StartCoroutine(FadeFromBlack(afterFadeAction));
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
