using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private People playerEnemy;
	private Vector3 initialPosition;
	public float delayMovement = 2.0f;
	private Vector3 targetPosition;
	private bool canMove;
	
	//0 = morto
	//1 = vivo
	private int state;

	void Start () 
	{
		playerEnemy = new People();
		playerEnemy.speed = 10.0f;
		
		initialPosition = new Vector3(6.3f,3.6f,0);
		transform.position = initialPosition;
	}
	
	void Update () 
	{
		//movement
		delayMovement -= Time.deltaTime;
		if(delayMovement <= 0.0f)
			canMove = true;

		if(canMove)
		{
			targetPosition = new Vector3(
				Random.Range(-7,8),
				Random.Range(-4,6),
				transform.position.z
			);
			canMove = false;
			delayMovement = 2.0f;
		}
		transform.position = Vector3.MoveTowards(
			transform.position,
			targetPosition,
			playerEnemy.speed * Time.deltaTime
		);
		
		//damage
		

	}
}
