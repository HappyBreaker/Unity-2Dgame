using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectControl : MonoBehaviour {

	[Header("坦克設定")]
	public GameObject Ob1;

	[Header("移動速度")]
	[Tooltip("0.25~10")]
	[Range(0.1f,10)]
	public float x;
	[Tooltip("0.25~10")]
	[Range(0.1f,10)]
	public float z;
	//public Rigidbody Ob2;

	// Use this for initialization
	void Start () {

		//Ob2 = GetComponents<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {

		/*if (Input.GetKeyDown(KeyCode.LeftArrow))	{Ob1.transform.Translate (1, 0, 0);	}
		if (Input.GetKeyDown(KeyCode.RightArrow))	{Ob1.transform.Translate (-1, 0, 0);}
		if (Input.GetKeyDown(KeyCode.UpArrow))		{Ob1.transform.Translate (0, 0, 1);}
		if (Input.GetKeyDown(KeyCode.DownArrow))	{Ob1.transform.Translate (0, 0, -1);}*/

		if (Input.GetKey(KeyCode.LeftArrow))	{Ob1.transform.position += new Vector3(x, 0, 0);	}
		if (Input.GetKey(KeyCode.RightArrow))	{Ob1.transform.position += new Vector3(-x, 0, 0);	}
		if (Input.GetKey(KeyCode.UpArrow))		{Ob1.transform.position += new Vector3(0, 0,-z);	}
		if (Input.GetKey(KeyCode.DownArrow))	{Ob1.transform.position += new Vector3(0, 0, z);	}
		if (Input.GetKeyDown(KeyCode.Space))	{Ob1.transform.position  = new Vector3(0, 0.0541f, 0);	}

		/*if (Input.GetKey(KeyCode.LeftArrow))	{Ob2.AddForce. += new Vector3(x, 0, 0);	}
		if (Input.GetKey(KeyCode.RightArrow))	{Ob2.transform.position += new Vector3(-x, 0, 0);	}
		if (Input.GetKey(KeyCode.UpArrow))		{Ob2.transform.position += new Vector3(0, 0,-z);	}
		if (Input.GetKey(KeyCode.DownArrow))	{Ob2.transform.position += new Vector3(0, 0, z);	}
		if (Input.GetKeyDown(KeyCode.Space))	{Ob2.transform.position  = new Vector3(0, 0.5f, 0);	}*/


		
	}
}
