﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public int health = 5;
	public int damage = 1;
	public float fireRate = 0.5f;
	public float reloadTime = 1f;
	public int bullets = 6;
	public int coins = 10;
	public int bombs = 2;
	public int upgradeCost = 20;

	public static GameManager gameManager;

	// Use this for initialization
	void Awake () {
		
		if(gameManager == null)
		{
			gameManager = this;
		}
		else
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
