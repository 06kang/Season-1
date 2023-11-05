using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Move : MonoBehaviour
{
    public Image image;
    float hAxis;
    Vector3 movevec;
    public float speed;
    bool jDown;
    bool isJump;
    public float jumpPower;
    public Transform hands;

    Rigidbody rigid;

    public GameObject bullet;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;

    public GameObject bullet5;
    public GameObject bullet6;
    public GameObject bullet7;
    public GameObject bullet8;

    public GameObject bullet9;
    public GameObject bullet10;
    public GameObject bullet11;
    public GameObject bullet12;

    public GameObject bullet13;
    public GameObject bullet14;
    public GameObject bullet15;
    public GameObject bullet16;


    public MeshCollider obj;

    public float cooltime, timer, cooltime2, timer2, cooltime3, timer3;

    [Serializable]
    public class ReBullet
    {
        Transform tr;
        MeshCollider obj;
        GameObject bullet;
        public float timer, cooltime;
        KeyCode key;
        public void Shot()
        {
            if (Input.GetKeyDown(key) && timer <= 0)
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (obj.Raycast(ray, out hit, 1000))
                {

                    Vector3 vec = hit.point - tr.position;
                    vec.z = 0;
                    GameObject go = Instantiate(bullet);
                    go.transform.position = tr.position + vec.normalized * 2;
                    go.GetComponent<HS_ProjectileMover>().direction = vec.normalized;
                    timer = cooltime;
                }

            }
            else
            {
                timer -= Time.deltaTime;
            }
        }

        public ReBullet(Transform tr, MeshCollider obj, GameObject bullet, float cooltime, KeyCode key)
        {
            this.tr = tr;
            this.obj = obj;
            this.bullet = bullet;
            this.cooltime = cooltime;
            this.key = key;
        }
    }

    public enum Season { spring, summur, autunm, winter };
    public Season SeasonSkil = Season.spring;
    // Start is called before the first frame update

    public ReBullet[] ShotBullet = new ReBullet[4];
    public int HP;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        ChangeSeason(SeasonSkil);
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        move();
        Jump();
        Shot();
        //Swap();

        //hands.transform.rotation = new Quaternion(10f, 20f, 30f, 1f);

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            print(SeasonSkil);
            if (SeasonSkil == Season.spring)
            {
                SeasonSkil = Season.summur;
                ChangeSeason(SeasonSkil);
            }
            else if (SeasonSkil == Season.summur)
            {
                SeasonSkil = Season.autunm;
                ChangeSeason(SeasonSkil);
            }
            else if (SeasonSkil == Season.autunm)
            {
                SeasonSkil = Season.winter;
                ChangeSeason(SeasonSkil);
            }
            else if (SeasonSkil == Season.winter)
            {
                SeasonSkil = Season.spring;
                ChangeSeason(SeasonSkil);
            }
        }
    }
        
            
        
    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0) Destroy(gameObject);
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        jDown = Input.GetButtonDown("Jump");
    }
    void move()
    {
        movevec = new Vector3(hAxis * speed, rigid.velocity.y, 0);
        rigid.velocity = movevec;
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJump = true;//มกวม
        }
        else if (Input.GetKeyUp(KeyCode.Space) && rigid.velocity.y > 0)
        {
            //rigid.velocity =rigid.velocity * 0.2f;

            float y = rigid.velocity.y * 0.4f;
            rigid.velocity = new Vector3(rigid.velocity.x, 0);
            rigid.AddForce(Vector3.up * y, ForceMode.Impulse);

        }

    }

    void Shot()
    {
        foreach(ReBullet shot in ShotBullet) shot.Shot();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJump = false;
        }
        if (collision.gameObject.tag == "Door")
        {
            SceneManager.LoadScene("Whynot");
        }
    }

    public void ChangeSeason(Season season)
    {
        switch (season)
        {
            case Season.spring:
                ShotBullet[0] = new ReBullet(transform, obj, bullet, 1, KeyCode.Mouse0);
                ShotBullet[1] = new ReBullet(transform, obj, bullet2, 4, KeyCode.Q);
                ShotBullet[2] = new ReBullet(transform, obj, bullet3, 7, KeyCode.E);
                ShotBullet[3] = new ReBullet(transform, obj, bullet4, 12, KeyCode.R);
                break;
            case Season.summur:
                ShotBullet[0] = new ReBullet(transform, obj, bullet5, 1, KeyCode.Mouse0);
                ShotBullet[1] = new ReBullet(transform, obj, bullet6, 4, KeyCode.Q);
                ShotBullet[2] = new ReBullet(transform, obj, bullet7, 7, KeyCode.E);
                ShotBullet[3] = new ReBullet(transform, obj, bullet8, 12, KeyCode.R);
                break;
            case Season.autunm:
                ShotBullet[0] = new ReBullet(transform, obj, bullet9, 1, KeyCode.Mouse0);
                ShotBullet[1] = new ReBullet(transform, obj, bullet10, 4, KeyCode.Q);
                ShotBullet[2] = new ReBullet(transform, obj, bullet11, 7, KeyCode.E);
                ShotBullet[3] = new ReBullet(transform, obj, bullet12, 12, KeyCode.R);
                break;
            case Season.winter:
                ShotBullet[0] = new ReBullet(transform, obj, bullet13, 1, KeyCode.Mouse0);
                ShotBullet[1] = new ReBullet(transform, obj, bullet14, 4, KeyCode.Q);
                ShotBullet[2] = new ReBullet(transform, obj, bullet15, 7, KeyCode.E);
                ShotBullet[3] = new ReBullet(transform, obj, bullet16, 12, KeyCode.R);
                break;
        }
    }

    /*void Swap()
    {
        if (SeasonSkil == Season.spring)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
                SeasonSkil = Season.summur;
        }
        else if(SeasonSkil == Season.summur)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
                SeasonSkil = Season.autunm;
        }
        else if(SeasonSkil == Season.autunm)
        {

        }
        else if(SeasonSkil == Season.winter)
        {

        }
    }*/
    
}