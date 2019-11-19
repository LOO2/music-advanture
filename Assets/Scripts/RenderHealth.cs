using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderHealth : MonoBehaviour {
	
	
	private People player;

	private int playerHealth;

	//RENDER HEARTS
	public int numOfHearts;

	public Image[] hearts;
	public Sprite fullHeart;
	public Sprite emptyHeart;

	
	void Start ()
	{
		player = GameObject.Find("Player").GetComponent<Player>().peoplePlayer;
		playerHealth = player.hp;

		RenderHearts();
	}

	

	public void RenderHearts()
	{
		for (int i = 0; i < hearts.Length; i++)
		{

			if(i < playerHealth)
			{
				hearts[i].sprite = fullHeart;
			}
			else
			{
				hearts[i].sprite = emptyHeart;
			}

			if(i < numOfHearts)
			{
				hearts[i].enabled = true;
			}
			else
			{
				hearts[i].enabled = false;
			}
		}
	}


}
