using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

	private bool isEnemy;

	private People player;

	private int playerHealth;


	void Start ()
	{
		player = GameObject.Find("Player").GetComponent<Player>().peoplePlayer;
		playerHealth = player.hp;
		isEnemy = false;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		
		if(IsEnemy(collision))
		{
			DamageOn();
		}

		isEnemy = false;
		
	}

	bool IsEnemy(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Enemy"))
			return true;
		//else if(collision.gameObject.CompareTag("Bullet"))
		//	return true;
		else
			return false;
		
	}

	void DamageOn()
	{
		Debug.Log("OI "+playerHealth);
		playerHealth -= 1;
		//RenderHearts();
		if(playerHealth <= 0)
			Die();
	}

	void Die()
	{
		Destroy(gameObject);
	}
	
}
