using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
	
	public int life;
	private bool isEnemy;

	private Rigidbody2D rbPlayer;

	private float delayImmortal;
	

	//RENDER HEARTS SPRITE
	public GameObject hearth;
	private Vector3 hearthPosition;
	private GameObject[] instanceHearth;
	private float[] instanceHearthPosX;
	private bool loseLife;
	private Sprite spriteOn;
	private Sprite spriteOff;
	private SpriteRenderer hearthSprite;

	//REFATORAR
	private int i = 0;
	private bool active = false;

	void Start ()
	{
		loseLife = false;
		isEnemy = false;
		rbPlayer = GetComponent<Rigidbody2D>();

		//Sprite
		spriteOn = Resources.Load("Sprites/hearts-1", typeof(Sprite)) as Sprite;
		spriteOff = Resources.Load("Sprites/hearts-2", typeof(Sprite)) as Sprite;

		//Position
		instanceHearth = new GameObject[10];
		instanceHearthPosX = new float[10];
		hearthPosition = new Vector3(9.3f,4,0);
		for(int i = 0; i < life; i++)
		{	
			instanceHearth[i] = Instantiate(hearth, hearthPosition,Quaternion.identity) as GameObject;
			instanceHearthPosX[i] = instanceHearth[i].transform.position.x;
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
		loseLife = true;
		life -= 1;
		if(life <= -0)
			Die();
		else
		{
			RenderHealth(loseLife);
			loseLife = false;

			//StartCoroutine(FlashingDamage());
		}
		
	}

	void Die()
	{
		Destroy(gameObject);
	}

	void RenderHealth(bool loseLife)
	{
		if(loseLife)
		{
			foreach(GameObject item in instanceHearth)
			{
				if(item.transform.position.x == MinFloatValue(instanceHearthPosX))
				{
					hearthSprite = item.GetComponent<SpriteRenderer>();
					hearthSprite.sprite = spriteOff;
				}
			}
		}
	}

	float MinFloatValue(float[] arrayValues)
	{
		float min = 100.0f;
		for (i = 1; i < arrayValues.Length; i++) 
		{
			//refatorar, retirar condição arrayValues[i] != 0
			if (arrayValues[i] < min && arrayValues[i] != 0)
			{
				min = arrayValues[i];
			}
		}
		return min;
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
