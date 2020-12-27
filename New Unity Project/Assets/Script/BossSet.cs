using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSet : MonoBehaviour {
	[Header("重生時間")]
	public float ReTime = 0;
	//[Header("循環時間")]
	//public float DestroyTime = 0f;
	public GameObject boss;
	

	void Start () {
		InvokeRepeating ("SpawnItems", ReTime, 1);
	}

	void SpawnItems () {
		Instantiate(boss,new Vector3(Random.Range(-5f,5f),0.35f,Random.Range(-4f,-1.5f)),Quaternion.identity);
	}

	public void TakeDamage(bool Alive = true)
	{
		if (Alive == false) 
		{
			Destroy (gameObject);
		}
	}
}
