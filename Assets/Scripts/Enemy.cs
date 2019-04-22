using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float moveSpeed;
	private Vector3 initialPosition;
	private Rigidbody2D rbEnemy;

	void Start () 
	{
		initialPosition = new Vector3(3,2,0);
		transform.position = initialPosition;
	}
	
	void Update () 
	{
		
	}
}
