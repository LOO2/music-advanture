using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

	//shot
	public GameObject bullet;
	private Transform bulletPoint;
	private float shotDelay = 1.0f;
	public int damage;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		shotDelay -= Time.deltaTime;
		if(shotDelay <= 0.0f)
		{
			Fire();
			shotDelay = 1.0f;
		}
		
	}

	private void Fire()
	{
		bulletPoint = GameObject.FindWithTag("Player").transform;
		Instantiate(bullet, bulletPoint.position, Quaternion.identity);
	}
}
