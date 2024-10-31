using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Text bulletsText;
	public Text healthText;
	public Slider healthBar;
	public Text coinsText;
	public Text bombsText;

    public static GameManager gameManager;
    // Use this for initialization
    void Awake () {

		UpdateHealthBar();
		UpdateCoins();

	}

    void SetCoins(int coin)
    {
        gameManager.coins -= coin; // Descuento de monedas
        FindObjectOfType<UIManager>().UpdateCoins(); // Actualiza el UI de monedas
    }


    public void UpdateBulletsUI(int bullets)
	{
		bulletsText.text = bullets.ToString();
	}

	public void UpdateHealthUI(int health)
	{
		healthText.text = health.ToString();
		healthBar.value = health;
	}

	public void UpdateCoins()
	{
		coinsText.text = GameManager.gameManager.coins.ToString();
	}

	public void UpdateBombs(int bombs)
	{
		bombsText.text = bombs.ToString();
	}

	public void UpdateHealthBar()
	{
		healthBar.maxValue = GameManager.gameManager.health;
	}
}
