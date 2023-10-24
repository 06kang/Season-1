using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextBox : MonoBehaviour
{
    public string[] texts;
    public Text t;
    public bool isAcitve= false;

    public static int count2;
    public NPC OpenNpc;

    public void OnTextBox(string[] texts, NPC npc = null)
    {
        OpenNpc = npc;
        this.texts = texts;
        gameObject.SetActive(true);
        StartCoroutine(OnCoroutine());
    }
    IEnumerator OnCoroutine()
    {
        isAcitve = true;
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

            while (!(Input.anyKeyDown && !Input.GetKeyDown(KeyCode.F))) yield return null;

        }
        gameObject.SetActive(false);
        if(OpenNpc)
        {
            OpenNpc.index++;
            OpenNpc = null;
        }
        isAcitve = false;
    }

}

