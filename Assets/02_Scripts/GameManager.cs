using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Move Player;

    public TextBox textBox;

    public Cinemachine.CinemachineVirtualCamera cm;

    public Image[] skilCool;
    public Text[] cooltimeTxt;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < skilCool.Length; i++)
        {
            skilCool[i].fillAmount = Player.ShotBullet[i].timer / Player.ShotBullet[i].cooltime;
            cooltimeTxt[i].text = ((int)Player.ShotBullet[i].timer+1).ToString();
            if (Player.ShotBullet[i].timer <= 0) cooltimeTxt[i].gameObject.SetActive(false);
            else cooltimeTxt[i].gameObject.SetActive(true);

        }

    }
}
