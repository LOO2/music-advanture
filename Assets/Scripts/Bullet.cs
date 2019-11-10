using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	//public float bulletVelocity = 1.0f;
	private Rigidbody bulletRb;

	void Start()
	{
		this.transform.parent = GameObject.Find("Shot").transform;
		bulletRb = GetComponent<Rigidbody>();
	}

	void Update()
	{	
		bulletRb.AddForce(bulletRb.position,ForceMode.Impulse);
	}

}
