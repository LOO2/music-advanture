using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour {

	public Rigidbody2D rbPeople;
	public string nickname;
	public Sprite sprite;
	public int hp;
	public float speed;
	public bool canMove;

	//sprites
	public SpriteRenderer playerSpriteRender; 
	public Sprite playerSpriteSide;
	public Sprite playerSpriteFront;
	public Sprite playerSpriteBack;
	//animation
	public Animator playerAnimator;

	public void Move(){

	}

	
	public void Attack(){

	}

	public void DamageHit(){

	}

	public void Die(){
		Destroy(this.gameObject);
	}

}
