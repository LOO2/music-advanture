using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float moveSpeed;
	private Vector3 initialPosition;
	public float countDown = 3.0f;
	private Vector3 targetPosition;
	private bool canMove;
	private Rigidbody2D rbEnemy;

	void Start () 
	{
		initialPosition = new Vector3(6.3f,3.6f,0);
		transform.position = initialPosition;
	}
	
	void Update () 
	{
		countDown -= Time.deltaTime;
		if(countDown <= 0.0f)
			canMove = true;

		if(canMove)
		{
			targetPosition = new Vector3(Random.Range(-8,8),Random.Range(-4,5),transform.position.z);
			Debug.Log(targetPosition);
			canMove = false;
			countDown = 3.0f;
		}

		transform.position = Vector3.MoveTowards(transform.position, targetPosition,moveSpeed * Time.deltaTime);
		
	}
}
