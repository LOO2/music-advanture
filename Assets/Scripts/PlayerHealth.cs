using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
	
	public int life;
	private bool isEnemy;

	private Rigidbody2D rbPlayer;

	private float delayImmortal;
	

	//RENDER HEARTS SPRITE
	public GameObject hearthOn;
	public GameObject hearthOff;
	private Vector3 hearthPosition;

	//REFATORAR
	private int i = 0;
	private bool active = false;

	void Start ()
	{
		isEnemy = false;
		rbPlayer = GetComponent<Rigidbody2D>();
		hearthPosition = new Vector3(9.3f,4,0);
		for(int i = 0; i < life; i++)
		{	
			Instantiate(hearthOn, hearthPosition,Quaternion.identity);
			hearthPosition.x = hearthPosition.x - 1.5f;
		}
		
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
		life -= 1;
		if(life <= -0)
			Die();
		else
		{
			//StartCoroutine(FlashingDamage());
		}
		
	}

	void Die()
	{
		Destroy(gameObject);
	}

	//REFATORAR---------------
	IEnumerator FlashingDamage()
	{	
		i += 1;
		active = !active;
		if(i<5){
			Debug.Log(active);
			gameObject.GetComponent<Renderer>().enabled = active;
			gameObject.SetActive(active);
			yield return new WaitForSeconds(0.5f);
			StartCoroutine(FlashingDamage());
		}
		gameObject.SetActive(true);
	}
	
}
