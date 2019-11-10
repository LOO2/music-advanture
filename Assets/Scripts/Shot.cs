using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

	//shot
	public GameObject bullet;
	private Transform bulletPoint;
	private Transform bulletTarget;
	private float bulletSpeed = 10.0f;
	private float shotDelay = 1.0f;
	private float shotCounter;
	public int damage;

	void Start () {
		GetComponent<Rigidbody>().velocity = transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
		
		bulletPoint = GameObject.FindWithTag("Player").transform;
		bulletTarget = GameObject.FindWithTag("Enemy").transform;

		shotDelay -= Time.deltaTime;
		if(shotDelay <= 0.0f)
		{
			Fire();
			shotDelay = 1.0f;
		}
		
	}

	private void Fire()
	{
		GameObject bulletClone = (GameObject)Instantiate(bullet, bulletPoint.position, Quaternion.identity);
	}
}
