using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform bulletTarget;
	private float bulletSpeed;

	
	void Start()
	{
		bulletSpeed = 30.0f;
		this.transform.parent = GameObject.Find("Gun").transform;
	}

	void Update()
	{	
		bulletTarget = GameObject.FindWithTag("Enemy").transform;
		
		transform.position = Vector3.MoveTowards(
			transform.position, bulletTarget.position, bulletSpeed * Time.deltaTime
		);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(!collision.gameObject.CompareTag("Player"))
			Destroy(gameObject);
	}

}
