using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour {

	public PlayerHealth playerHealth;
	public float restartDelay = 5f;

	private Animator anim;
	private float restartTime;

	void Awake () {
		anim = GetComponent<Animator>();
	}
	
	void Update () {
		if (playerHealth.health <= 0)
		{
			anim.SetTrigger("GameOver");
			restartTime += Time.deltaTime;
			if (restartTime >= restartDelay)
			{
				//Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}
