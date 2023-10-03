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
    
    // Start is called before the first frame update
    void Start()
    {
        
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
            Destroy(gameObject);
        }
    }
}
