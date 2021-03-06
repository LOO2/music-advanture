﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	private Rigidbody2D rbPlayer;
	
	public People peoplePlayer;
	private Vector3 initialPosition;
	
	private Vector3 mouseTargetPosition;
	private RenderHealth playerHP;

	void Start () 
	{
		peoplePlayer = new People();
		playerHP = new RenderHealth();
		peoplePlayer.speed = 10.0f;
		peoplePlayer.hp = 3;
		
		initialPosition = new Vector3(-6,0,0);
		transform.position = initialPosition;

		mouseTargetPosition = initialPosition;
		rbPlayer = GetComponent<Rigidbody2D>();

		//sprites 
		peoplePlayer.playerSpriteRender = GetComponent<SpriteRenderer>();
		if(peoplePlayer.playerSpriteRender.sprite == null)
		{
			//playerSpriteRender.sprite = playerSpriteSide;
			peoplePlayer.playerSpriteRender.sprite = peoplePlayer.playerSpriteSide;
		}

		//animation
		peoplePlayer.playerAnimator = GetComponent<Animator>();
	}
	
	void OnTriggerEnter2D (Collider2D collision)
	{
		Debug.Log("Teste");
		if(IsEnemy(collision))
		{
			peoplePlayer.DamageHit(1);
			playerHP.RenderHearts(peoplePlayer.hp);
			if(peoplePlayer.hp <= 0)
				peoplePlayer.Die();
		}
	}

	bool IsEnemy(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Enemy"))
			return true;
		//else if(collision.gameObject.CompareTag("Bullet"))
		//	return true;
		else
			return false;
		
	}

	void Update () 
	{
		//attack
		peoplePlayer.Attack();

		//mouse movement
		if(Input.GetKeyDown(KeyCode.Mouse1))
		{
            mouseTargetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mouseTargetPosition.z = transform.position.z;
			ChangeTheDamnSprite(mouseTargetPosition);
		}
        transform.position = Vector3.MoveTowards(transform.position, mouseTargetPosition, peoplePlayer.speed * Time.deltaTime);

		if(rbPlayer.transform.position.y == mouseTargetPosition.y || rbPlayer.transform.position.x == mouseTargetPosition.x)
		{
			//sprite
			peoplePlayer.playerSpriteRender.sprite = peoplePlayer.playerSpriteBack;
			peoplePlayer.playerSpriteRender.flipX = false;

			//animation
			peoplePlayer.playerAnimator.SetBool("walkFront",false);
			peoplePlayer.playerAnimator.SetBool("walkBack",false);
			peoplePlayer.playerAnimator.SetBool("walkSide",false);
		}
	}

	//Sprite
	void ChangeTheDamnSprite (Vector3 distancePlayerTarget)
	{
		if(rbPlayer.transform.position.x > mouseTargetPosition.x)
		{
			//sprite
			peoplePlayer.playerSpriteRender.sprite = peoplePlayer.playerSpriteSide;
			peoplePlayer.playerSpriteRender.flipX = true;

			//animation
			peoplePlayer.playerAnimator.SetBool("walkFront",false);
			peoplePlayer.playerAnimator.SetBool("walkBack",false);
			peoplePlayer.playerAnimator.SetBool("walkSide",true);
		}
		else if(rbPlayer.transform.position.x < mouseTargetPosition.x)
		{
			//sprite
			peoplePlayer.playerSpriteRender.sprite = peoplePlayer.playerSpriteSide;
			peoplePlayer.playerSpriteRender.flipX = false;

			//animation
			peoplePlayer.playerAnimator.SetBool("walkFront",false);
			peoplePlayer.playerAnimator.SetBool("walkBack",false);
			peoplePlayer.playerAnimator.SetBool("walkSide",true);
		}
		if(rbPlayer.transform.position.y > mouseTargetPosition.y)
		{
			//sprite
			peoplePlayer.playerSpriteRender.sprite = peoplePlayer.playerSpriteFront;
			peoplePlayer.playerSpriteRender.flipX = false;
			
			//animation
			peoplePlayer.playerAnimator.SetBool("walkFront",true);
			peoplePlayer.playerAnimator.SetBool("walkBack",false);
			peoplePlayer.playerAnimator.SetBool("walkSide",false);
		}
		else if(rbPlayer.transform.position.y < mouseTargetPosition.y)
		{
			//sprite
			peoplePlayer.playerSpriteRender.sprite = peoplePlayer.playerSpriteBack;
			peoplePlayer.playerSpriteRender.flipX = false;

			//animation
			peoplePlayer.playerAnimator.SetBool("walkFront",false);
			peoplePlayer.playerAnimator.SetBool("walkBack",true);
			peoplePlayer.playerAnimator.SetBool("walkSide",false);
		}
	}
	
}
