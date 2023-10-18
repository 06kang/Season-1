using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject btn;

    [Serializable]
    public class Array
    {
        public string[] texts;
    }
    public Array[] Contents;
    public int count;
    public int count2;
    public int ck;

    public GameObject obj;

    public Vector3 vector;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        int layerMask = 1 << LayerMask.NameToLayer("Player");
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 3, Vector3.zero, 0, layerMask);
        
        if (hit.collider)
        {
            print(hit.collider.name);
        }

        */

        int layerMask = 1 << LayerMask.NameToLayer("Player");
        Collider[] hit = Physics.OverlapSphere(transform.position, 2, layerMask);

        if (hit.Length > 0)
        {
            btn.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F) /*&& tests.Length > count*/)
            {
                GameManager.instance.textBox.OnTextBox(Contents[count].texts);
                count++;
                count2++;
            }
        }
        else
        {
            btn.SetActive(false);
        }

        Telpo(vector);
        
    }

    void Telpo(Vector3 pos)
    {
        if (count2 == ck)
        {
            obj.transform.position = pos;
            count2 = 0;
            GameObject.Find("Fade").GetComponent<FadeOutAnim>().FadeIn();
        }
    }
    
}
