using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

	//shot
	public GameObject bullet;
	private Transform bulletPoint;
	private Transform bulletTarget;
	private float bulletSpeed = 10.0f;
	public float shotDelay = 1.0f;
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

	public void Fire()
	{
		GameObject bulletClone = (GameObject)Instantiate(bullet, bulletPoint.position, Quaternion.identity);
		bulletClone.transform.parent = GameObject.Find("bullet").transform;

		Rigidbody bulletRb = GetComponent<Rigidbody>();
		//bulletRb.AddForce(GetComponent<Rigidbody>().position,ForceMode.Acceleration);

		bulletClone.transform.position = Vector3.MoveTowards(
			bulletPoint.position, 
			bulletTarget.position, 
			bulletSpeed * Time.deltaTime
		);
	}
}
