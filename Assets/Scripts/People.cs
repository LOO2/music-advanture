using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People{

	//public string nickname;
	//public Sprite sprite;
	public int hp;
	public float speed;


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

	public void DamageHit(int damage){
		this.hp = this.hp - damage;
	}

	public void Die(){
		//Destroy(this.gameObject);
	}

}
