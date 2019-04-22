using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float moveSpeed;
	private Vector3 initialPosition;
	public float countDown = 2.0f;
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
			targetPosition = new Vector3(Random.Range(-7,8),Random.Range(-4,6),transform.position.z);
			canMove = false;
			countDown = 2.0f;
		}
		transform.position = Vector3.MoveTowards(transform.position, targetPosition,moveSpeed * Time.deltaTime);
		
	}
}
