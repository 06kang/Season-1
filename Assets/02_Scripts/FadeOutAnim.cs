using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeOutAnim : MonoBehaviour
{

    public float fadeSpeed = 1.5f;
    public bool fadeInOnStart = false;
    public bool fadeOutOnExit = false;
    public bool isFade;
    public CanvasGroup canvasGroup;

    /*public enum FadeKind { FadeIn, FadeOut };
    public FadeKind fade;*/

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    void Update()
    {
    }

    public IEnumerator FadeIn()
    {
        while (canvasGroup.alpha <= 1)
        {
            canvasGroup.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }
        isFade = false;
        gameObject.SetActive(true);
    }

    public IEnumerator FadeOut()
    {
        while(canvasGroup.alpha >= 1)
        {
            canvasGroup.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }
        isFade = true;
        gameObject.SetActive(false);
    }
    public IEnumerator FadeInOut()
    {
        while (canvasGroup.alpha <= 1)
        {
            canvasGroup.alpha += Time.deltaTime * fadeSpeed;
            yield return null;        
        }
        
        isFade = false;
        while (canvasGroup.alpha >= 1)
        {
            canvasGroup.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }
        isFade = true;
    }
}