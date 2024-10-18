using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayShop : MonoBehaviour {

	public GameObject shopPanel;

	private void OnTriggerEnter2D(Collider2D other)
	{
		Player player = other.GetComponent<Player>();
		if(player != null)
		{
			player.canFire = false;
			shopPanel.SetActive(true);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		Player player = other.GetComponent<Player>();
		if (player != null)
		{
			player.canFire = true;
			shopPanel.SetActive(false);
		}
	}
}
