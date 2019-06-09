using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	
	private bool isEnemy;

	private Rigidbody2D rbPlayer;

	private float delayImmortal;
	
	//RENDER HEARTS
	public int health;
	public int numOfHearts;

	public Image[] hearts;
	public Sprite fullHeart;
	public Sprite emptyHeart;

	
	void Start ()
	{
		isEnemy = false;
		rbPlayer = GetComponent<Rigidbody2D>();

		RenderHearts();		
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
		RenderHearts();
		if(health <= 0)
			Die();
	}

	void Die()
	{
		Destroy(gameObject);
	}

	void RenderHearts()
	{
		for (int i = 0; i < hearts.Length; i++)
		{

			if(i < health)
			{
				hearts[i].sprite = fullHeart;
			}
			else
			{
				hearts[i].sprite = emptyHeart;
			}

			if(i < numOfHearts)
			{
				hearts[i].enabled = true;
			}
			else
			{
				hearts[i].enabled = false;
			}
		}
	}


}
