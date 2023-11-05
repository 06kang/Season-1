using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack1 : MonoBehaviour
{
    public Animator anim;
    bool isAttackReady, isAttack;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        int layerMask = 1 << LayerMask.NameToLayer("Player");
        RaycastHit[] detect = Physics.SphereCastAll(transform.position, 10, Vector3.up, 0, layerMask);
        if (detect.Length > 0)
        {
            isAttackReady = true;
        }
        else
        {
            isAttackReady = false;
        }

        if (isAttackReady)
        {
            RaycastHit[] attack = Physics.SphereCastAll(transform.position, 5, Vector3.up, 0, layerMask);
            if (attack.Length > 0)
            {
                if (!isAttack)
                {
                    int value = Random.Range(1, 5);
                    anim.SetInteger("Attack", value);
                    if(value == 1) Invoke("GiveDamage", 0.33f * 2);
                    else if(value == 2) Invoke("GiveDamage", 0.66f * 2);
                    else if (value == 3) Invoke("GiveDamage", 0.73f *2);
                    else if (value == 4) Invoke("GiveDamage", 0.5f*2);

                    isAttack = true;
                    Invoke("ResetBool", 2f);
                    //anim.SetInteger("Attack", 0);
                }
                

            }
            else
            {
                isAttack = false;
                anim.SetInteger("Attack", 0);
            }
        }
    }
    public void GiveDamage()
    {
        int layerMask = 1 << LayerMask.NameToLayer("Player");
        RaycastHit[] detect = Physics.SphereCastAll(transform.position, 5, Vector3.up, 0, layerMask);
        if (detect.Length > 0)
        {
            detect[0].collider.GetComponent<Move>().TakeDamage(5);
        }

    }

    void ResetBool()
    {
        isAttack = false;
    }
}
