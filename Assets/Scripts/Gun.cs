using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	//shot
	public GameObject bullet;
	private Transform bulletPoint;
	private float shotDelay;
	public int damage;

	void Start () {
		shotDelay = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		shotDelay -= Time.deltaTime;
		if(shotDelay <= 0.0f)
		{
			Shoot();
			shotDelay = 0.5f;
		}
		
	}

	private void Shoot(){
		bulletPoint = GameObject.FindWithTag("Player").transform;
		Instantiate(bullet, bulletPoint.position, Quaternion.identity);
	}
}
