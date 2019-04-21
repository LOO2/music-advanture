using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float moveSpeed;

	private Vector3 initialPosition;
	private Rigidbody2D rbPlayer;
	
	private Vector3 mouseTargetPosition;

	//sprites
	private SpriteRenderer playerSpriteRender; 
	public Sprite playerSpriteRight;
	public Sprite playerSpriteLeft;
	public Sprite playerSpriteUP;
	public Sprite playerSpriteDown;
	


	void Start () 
	{
		initialPosition = new Vector3(-5,0,0);
		transform.position = initialPosition;

		mouseTargetPosition = initialPosition;

		rbPlayer = GetComponent<Rigidbody2D>();

		//sprites
		playerSpriteRender = GetComponent<SpriteRenderer>();
		if(playerSpriteRender.sprite == null)
		{
			playerSpriteRender.sprite = playerSpriteRight;
		}
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
			playerSpriteRender.sprite = playerSpriteLeft;
			playerSpriteRender.flipX = true;
		}
		else if(rbPlayer.transform.position.x < mouseTargetPosition.x)
		{
			playerSpriteRender.sprite = playerSpriteRight;
			playerSpriteRender.flipX = false;
		}

		if(rbPlayer.transform.position.y > mouseTargetPosition.y)
		{
			playerSpriteRender.sprite = playerSpriteDown;
		}
		else if(rbPlayer.transform.position.y < mouseTargetPosition.y)
		{
			playerSpriteRender.sprite = playerSpriteUP;
		}
	}
}
