using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
	
	public int health; 
	private float posZ;
	
	void Start ()
	{
		posZ = transform.rotation.z;
	}
	
	void Update ()
	{
		
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		transform.rotation = Quaternion.Euler(0, 0, 0);
	}
}
