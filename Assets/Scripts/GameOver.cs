using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	private People player;
	public RenderHealth playerHealth;
	private Animator anim;

	void Start()
	{
		player = GameObject.Find("Player").GetComponent<Player>().peoplePlayer;
	}

	void Awake () 
	{
		anim = GetComponent<Animator>();
	}
	
	void Update () {
		if (player.hp <= 0)
		{
			anim.SetTrigger("GameOver");
		}
	}
}
