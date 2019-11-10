using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform bulletTarget;
	private float bulletSpeed;

	//public float bulletVelocity = 1.0f;
	private Rigidbody bulletRb;

	void Start()
	{
		bulletSpeed = 40.0f;
		this.transform.parent = GameObject.Find("Shot").transform;
		bulletRb = GetComponent<Rigidbody>();
	}

	void Update()
	{	
		bulletTarget = GameObject.FindWithTag("Enemy").transform;
		//bulletRb.AddForce(bulletTarget.position,ForceMode.Impulse);

		transform.position = Vector3.MoveTowards(
			transform.position, bulletTarget.position, bulletSpeed * Time.deltaTime
		);

		if(transform.position == bulletTarget.position)
			Destroy(gameObject);

	}

}
