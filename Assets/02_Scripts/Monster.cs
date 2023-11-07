using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public float maxHp;
    public float curHp;
    public float Damage;
    public Transform target;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float Damage)
    {
        curHp -= Damage;
        if(curHp <= 0)
        {
            int value = 1;
            anim.SetInteger("Dead", value);
        }
    }
    
}
