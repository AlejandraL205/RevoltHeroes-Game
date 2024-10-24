using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeShop : MonoBehaviour {

	public Text healthText, damageText, fireRateText, bulletsText, reloadTimeText, upgradeCostText;

	GameManager gameManager;
	Player player;

	// Use this for initialization
	void Start () {

		gameManager = GameManager.gameManager;
		player = FindObjectOfType<Player>();
		UpdateUI();

	}
	
	void UpdateUI()
	{
		healthText.text = "Health: " + gameManager.health;
		damageText.text = "Damage: " + gameManager.damage;
		fireRateText.text = "Fire Rate: " + gameManager.fireRate;
		bulletsText.text = "Bullets: " + gameManager.bullets;
		reloadTimeText.text = "Reload Time: " + gameManager.reloadTime;
		upgradeCostText.text = "Upgrade Cost: " + gameManager.upgradeCost;
	}

	public void SetHealth()
	{
		if(gameManager.coins >= gameManager.upgradeCost)
		{
			gameManager.health++;
			FindObjectOfType<UIManager>().UpdateHealthBar();
			player.SetPlayerStatus();
			SetCoins(gameManager.upgradeCost);
			gameManager.upgradeCost += (gameManager.upgradeCost / 5);
			UpdateUI();
		}
	}

	public void SetDamage()
	{
		if (gameManager.coins >= gameManager.upgradeCost)
		{
			gameManager.damage++;
			
			player.SetPlayerStatus();
			SetCoins(gameManager.upgradeCost);
			gameManager.upgradeCost += (gameManager.upgradeCost / 5);
			UpdateUI();
		}
	}

	public void SetFireRate()
	{
		if (gameManager.coins >= gameManager.upgradeCost)
		{
			gameManager.fireRate -= 0.1f;

			if(gameManager.fireRate <= 0)
			{
				gameManager.fireRate = 0;
			}

			player.SetPlayerStatus();
			SetCoins(gameManager.upgradeCost);
			gameManager.upgradeCost += (gameManager.upgradeCost / 5);
			UpdateUI();
		}
	}

	public void SetBullets()
	{
		if (gameManager.coins >= gameManager.upgradeCost)
		{
			gameManager.bullets++;

			player.SetPlayerStatus();
			SetCoins(gameManager.upgradeCost);
			gameManager.upgradeCost += (gameManager.upgradeCost / 5);
			UpdateUI();
		}
	}

	public void SetReloadTime()
	{
		if (gameManager.coins >= gameManager.upgradeCost)
		{
			gameManager.reloadTime -= 0.1f;

			if (gameManager.reloadTime <= 0)
			{
				gameManager.reloadTime = 0;
			}

			player.SetPlayerStatus();
			SetCoins(gameManager.upgradeCost);
			gameManager.upgradeCost += (gameManager.upgradeCost / 5);
			UpdateUI();
		}
	}

	void SetCoins(int coin)
	{
		gameManager.coins -= coin;
		FindObjectOfType<UIManager>().UpdateCoins();
	}
}
