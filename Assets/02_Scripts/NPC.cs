using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public int count, index;
    public int ck;

    public GameObject obj;

    public Vector3 vector, pos;

    public bool fade = true;
    public enum TelpoMan { TelpoGo, NotTelpo };
    public TelpoMan man;
    
    
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
            if (Input.GetKeyDown(KeyCode.F) && Contents.Length > count && !GameManager.instance.textBox.isAcitve)
            {
                GameManager.instance.textBox.OnTextBox(Contents[count].texts, this);

                count++;
            }
        }
        else
        {
            btn.SetActive(false);
        }
        if(man == TelpoMan.TelpoGo)
        {
            Telpo(vector);
        }
    }

    void Telpo(Vector3 pos)
    {
        
        if (index == ck)
        {
            this.pos = pos;
            Invoke("Teleport", 2.1f);
            index = 0;
            if(fade == true)
            {
                GameObject.Find("Fade").GetComponent<FadeOutAnim>().StartCoroutine("FadeInOut");

            }
        }
    }

    void Teleport()
    {
        obj.transform.position = pos;
    }
    
}
