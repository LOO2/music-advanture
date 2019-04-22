using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
	
	public int health;
	private bool isEnemy;

	private Rigidbody2D rbPlayer;
	
	void Start ()
	{
		isEnemy = false;
		rbPlayer.GetComponent<Rigidbody2D>();
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
		else
		{
			gameObject.SetActive(true);
			//yield return new WaitForSeconds(0.1f);
			gameObject.SetActive(false);
		}
	}

	void Die()
	{
		Destroy(gameObject);
	}
	
}
