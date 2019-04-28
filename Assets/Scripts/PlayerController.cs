using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	public float moveSpeed;
	private Vector3 initialPosition;
	private Rigidbody2D rbPlayer;
	private Vector3 mouseTargetPosition;

	//sprites
	private SpriteRenderer playerSpriteRender; 
	public Sprite playerSpriteSide;
	public Sprite playerSpriteBack;
	public Sprite playerSpriteFront;
	
	//animation
	Animator playerAnimator;

	void Start () 
	{
		initialPosition = new Vector3(-6,0,0);
		transform.position = initialPosition;

		mouseTargetPosition = initialPosition;

		rbPlayer = GetComponent<Rigidbody2D>();

		//sprites 
		playerSpriteRender = GetComponent<SpriteRenderer>();
		if(playerSpriteRender.sprite == null)
		{
			playerSpriteRender.sprite = playerSpriteSide;
		}

		//animation
		playerAnimator = GetComponent<Animator>();
	}
	
	void FixedUpdate ()
	{
		
	}

	void Update () 
	{
		//mouse movement
		if(Input.GetKeyDown(KeyCode.Mouse1))
		{
            mouseTargetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mouseTargetPosition.z = transform.position.z;
			ChangeTheDamnSprite(mouseTargetPosition);
		}
        transform.position = Vector3.MoveTowards(transform.position, mouseTargetPosition, moveSpeed * Time.deltaTime);

		if(rbPlayer.transform.position.y == mouseTargetPosition.y || rbPlayer.transform.position.x == mouseTargetPosition.x)
		{
			//sprite
			playerSpriteRender.sprite = playerSpriteBack;
			playerSpriteRender.flipX = false;

			//animation
			playerAnimator.SetBool("walkFront",false);
			playerAnimator.SetBool("walkBack",false);
			playerAnimator.SetBool("walkSide",false);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{

	}

	void ChangeTheDamnSprite (Vector3 distancePlayTarget)
	{
		//distancePlayTarget = mouseTargetPosition - rbPlayer.transform.position;
		//Debug.Log(Mathf.Max(rbPlayer.transform.position.x, distancePlayTarget.x));

		if(rbPlayer.transform.position.x > mouseTargetPosition.x)
		{
			//sprite
			playerSpriteRender.sprite = playerSpriteSide;
			playerSpriteRender.flipX = true;

			//animation
			playerAnimator.SetBool("walkFront",false);
			playerAnimator.SetBool("walkBack",false);
			playerAnimator.SetBool("walkSide",true);
		}
		else if(rbPlayer.transform.position.x < mouseTargetPosition.x)
		{
			//sprite
			playerSpriteRender.sprite = playerSpriteSide;
			playerSpriteRender.flipX = false;

			//animation
			playerAnimator.SetBool("walkFront",false);
			playerAnimator.SetBool("walkBack",false);
			playerAnimator.SetBool("walkSide",true);
		}

		if(rbPlayer.transform.position.y > mouseTargetPosition.y)
		{
			//sprite
			playerSpriteRender.sprite = playerSpriteFront;
			playerSpriteRender.flipX = false;
			
			//animation
			playerAnimator.SetBool("walkFront",true);
			playerAnimator.SetBool("walkBack",false);
			playerAnimator.SetBool("walkSide",false);
		}
		else if(rbPlayer.transform.position.y < mouseTargetPosition.y)
		{
			//sprite
			playerSpriteRender.sprite = playerSpriteBack;
			playerSpriteRender.flipX = false;

			//animation
			playerAnimator.SetBool("walkFront",false);
			playerAnimator.SetBool("walkBack",true);
			playerAnimator.SetBool("walkSide",false);
		}
		
	}

	
	
}
