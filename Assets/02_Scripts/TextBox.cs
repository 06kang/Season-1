using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextBox : MonoBehaviour
{
    public string[] texts;
    public Text t;
    bool nextT = false;

    public void OnTextBox(string[] texts)
    {
        this.texts = texts;
        gameObject.SetActive(true);
        StartCoroutine(OnCoroutine());
    }
    IEnumerator OnCoroutine()
    {
        t.text = "";
        for (int i = 0; i < texts.Length; i++)
        {
            string textTemp = texts[i];
            for (int j = 0; j < textTemp.Length; j++)
            {
                t.text = textTemp.Substring(0, j);
                yield return new WaitForSeconds(0.05f);
            }
            t.text = textTemp;

            while (!Input.anyKeyDown) yield return null;

        }
        gameObject.SetActive(false);
    }

}
