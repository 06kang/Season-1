using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FadeOutAnim : MonoBehaviour
{

    public float fadeSpeed = 1.5f;
    public bool fadeInOnStart = false;
    public bool fadeOutOnExit = false;
    public bool isFade;
    public CanvasGroup canvasGroup;
    public enum FadeKind { FadeIn, FadeOut };
    public FadeKind fade;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public IEnumerator FadeIn()
    {
        //while (canvasGroup.alpha < 1)
        //{
        //    canvasGroup.alpha += Time.deltaTime * fadeSpeed;
        //    yield return null;
        //}
        //isFade = false;
        //gameObject.SetActive(true);

        for(int i=1; i<=100; i++)
        {
            canvasGroup.alpha = i * 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        isFade = false;
        gameObject.SetActive(true);
    }

    public IEnumerator FadeOut()
    {
        for (int i = 100; i >= 0; i--)
        {
            canvasGroup.alpha = i * 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        isFade = true;
        gameObject.SetActive(false);
    }


    public void ActiveFade()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (fade == FadeKind.FadeIn)
        {
            gameObject.SetActive(true);
            canvasGroup.alpha = 0f;
            StartCoroutine(FadeIn());

        }
        else
        {
            enabled = true;
            canvasGroup.alpha = 1f;
            StartCoroutine(FadeOut());

        }
        isFade = true;
    }

}