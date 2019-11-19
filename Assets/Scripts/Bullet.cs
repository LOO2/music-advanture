using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform bulletTarget;
	private float bulletSpeed;

	private Rigidbody bulletRb;

	void Start()
	{
		bulletSpeed = 40.0f;
		this.transform.parent = GameObject.Find("Gun").transform;
		bulletRb = GetComponent<Rigidbody>();
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(!collision.gameObject.CompareTag("Player"))
			Destroy(gameObject);
	}

	void Update()
	{	
		bulletTarget = GameObject.FindWithTag("Enemy").transform;
		
		transform.position = Vector3.MoveTowards(
			transform.position, bulletTarget.position, bulletSpeed * Time.deltaTime
		);

		if(transform.position == bulletTarget.position)
			Destroy(gameObject);

	}

}
