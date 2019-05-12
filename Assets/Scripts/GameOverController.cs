using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour {

	public PlayerHealth playerHealth;
	private Animator anim;

	void Awake () {
		anim = GetComponent<Animator>();
	}
	
	void Update () {
		if (playerHealth.health <= 0)
		{
			anim.SetTrigger("GameOver");
		}
	}
}
