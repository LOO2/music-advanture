using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	private Rigidbody2D rbPlayer;
	
	public People peoplePlayer;
	private Vector3 initialPosition;
	
	private Vector3 mouseTargetPosition;

	void Start () 
	{
		peoplePlayer = new People();
		peoplePlayer.speed = 10.0f;
		
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
	
	void FixedUpdate ()
	{
		
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

	void OnCollisionEnter2D(Collision2D collision)
	{
		
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
