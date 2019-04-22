using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
	
	public int health;
	private bool isEnemy;
	
	void Start ()
	{
		isEnemy = false;
	}
	
	void Update ()
	{
		
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		
		if(IsEnemy(collision))
		{
			Damage();	
		}

		isEnemy = false;
	}

	bool IsEnemy(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Enemy"))
			return true;
		else
			return false;
	}

	void Damage()
	{
		health -= 1;
		if(health <= 0)
			Die();
	}

	void Die()
	{
		Destroy(gameObject);
	}
	
}
