using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
	public GameObject bulletP;
	public Transform bulletSpwan;
	public int damage;
	Rigidbody rigid;
	float bulletSpeed = 15f;
    void Update()
	{
		//StartCoroutine("Shot");	
		rigid.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
	}
	void Awake()
	{
        rigid = GetComponent<Rigidbody>();
    }
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Wall")    //ÃÑ¾Ë
			Destroy(gameObject);
		if(collision.gameObject.tag == "Ground")
			Destroy(gameObject);

	}
	IEnumerator Shot()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			GameObject bullet = Instantiate(bulletP, bulletSpwan.position, bulletSpwan.rotation);
            rigid.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
			yield return new WaitForSeconds(0.5f);
        }
	}
}