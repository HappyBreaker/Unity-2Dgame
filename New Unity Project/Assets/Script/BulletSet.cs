using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSet : MonoBehaviour 
{

	[Header("子彈速度")]
	[Range(1,100)]
	public float speed = 20f;
	[Header("子彈物件")]
	public Rigidbody rb;
	
	void Start() 
	{
		rb.velocity = transform.forward * speed;	
	}


	void OnTriggerEnter (Collider other)
	{
		BossSet bossSet = other.GetComponent<BossSet> (); 
		if (bossSet != null) {
			bossSet.TakeDamage (false);
		}
	}
}
