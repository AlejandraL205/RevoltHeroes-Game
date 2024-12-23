﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float speed = 5f;
	public float jumpForce = 600;
	public GameObject bulletPrefab;
	public Transform shotSpawner;
	public Rigidbody2D bomb;
	public float damageTime = 1f;
	public bool canFire = true;

	private Animator anim;
	private Rigidbody2D rb2d;
	private bool facingRight = true;
	private bool jump;
	private bool onGround = false;
	private Transform groundCheck;
	private float hForce = 0;
	private bool crouched;
	private bool lookingUp;
	private bool reloading;
	private float fireRate = 0.5f;
	private float nextFire;
	private bool tookDamage = false;

	private int bullets;
	private float reloadTime;
	private int health;
	private int maxHealth;
	private int bombs;

	private bool isDead = false;

	GameManager gameManager;

	// Use this for initialization
	void Start () {

		rb2d = GetComponent<Rigidbody2D>();
		groundCheck = gameObject.transform.Find("GroundCheck");
		anim = GetComponent<Animator>();

		gameManager = GameManager.gameManager;

		SetPlayerStatus();
		bombs = gameManager.bombs;
		health = maxHealth;

		UpdateBulletsUI();
		UpdateBombsUI();
		UpdateHealthUI();

	}
	
	// Update is called once per frame
	void Update () {

		if (!isDead)
		{
			onGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

			
			if (onGround)
			{
				anim.SetBool("Jump", false);
			}

			if (Input.GetButtonDown("Jump") && onGround && !reloading)
			{
				jump = true;
			}
			else if (Input.GetButtonUp("Jump"))
			{
				if(rb2d.velocity.y > 0)
				{
					rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y * 0.5f);
				}
			}

			if (Input.GetButtonDown("Fire1") && Time.time > nextFire && bullets > 0 && !reloading && canFire)
			{
				nextFire = Time.time + fireRate;
				anim.SetTrigger("Shoot");
				GameObject tempBullet = Instantiate(bulletPrefab, shotSpawner.position, shotSpawner.rotation);
				if (!facingRight && !lookingUp)
				{
					tempBullet.transform.eulerAngles = new Vector3(0, 0, 180);
				}
				else if(!facingRight && lookingUp)
				{
					tempBullet.transform.eulerAngles = new Vector3(0, 0, 90);
				}
				if(crouched && !onGround)
				{
					tempBullet.transform.eulerAngles = new Vector3(0, 0, -90);
				}

				bullets--;
				UpdateBulletsUI();
				
			}
			else if(Input.GetButtonDown("Fire1") && bullets <= 0 && onGround)
			{
				StartCoroutine(Reloading());
			}

				lookingUp = Input.GetButton("Up");
			crouched = Input.GetButton("Down");

			anim.SetBool("LookingUp", lookingUp);
			anim.SetBool("Crouched", crouched);

			if (Input.GetButtonDown("Reload") && onGround)
			{
				StartCoroutine(Reloading());
			}

			if(Input.GetButtonDown("Fire2") && bombs > 0)
			{
				Rigidbody2D tempBomb = Instantiate(bomb, transform.position, transform.rotation);
				if (facingRight)
				{
					tempBomb.AddForce(new Vector2(8, 10), ForceMode2D.Impulse);
				}
				else
				{
					tempBomb.AddForce(new Vector2(-8, 10), ForceMode2D.Impulse);
				}

				bombs--;
				UpdateBombsUI();
			}

			if((crouched || lookingUp || reloading) && onGround)
			{
				hForce = 0;
			}
		}

	}

	private void FixedUpdate()
{
    if (!isDead)
    {
        // Movimiento horizontal
        float hForce = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(hForce * speed, rb2d.velocity.y);

        // Salto
        if (Input.GetButtonDown("Jump") && onGround)
        {
            rb2d.AddForce(Vector2.up * jumpForce);
        }

        // Comprobación de la animación y giro del personaje
        anim.SetFloat("Speed", Mathf.Abs(hForce));
        if (hForce > 0 && !facingRight)
        {
            Flip();
        }
        else if (hForce < 0 && facingRight)
        {
            Flip();
        }
    }
}


	IEnumerator Reloading()
	{
		reloading = true;
		anim.SetBool("Reloading", true);
		yield return new WaitForSeconds(reloadTime);
		bullets = gameManager.bullets;
		reloading = false;
		anim.SetBool("Reloading", false);
		UpdateBulletsUI();
	}

	void Flip()
	{
		facingRight = !facingRight;

		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	public void SetPlayerStatus()
	{
		fireRate = gameManager.fireRate;
		bullets = gameManager.bullets;
		reloadTime = gameManager.reloadTime;
		maxHealth = gameManager.health;
	}

	void UpdateBulletsUI()
	{
		FindObjectOfType<UIManager>().UpdateBulletsUI(bullets);
	}

	void UpdateBombsUI()
	{
		FindObjectOfType<UIManager>().UpdateBombs(bombs);
		gameManager.bombs = bombs;
	}

	void UpdateHealthUI()
	{
		FindObjectOfType<UIManager>().UpdateHealthUI(health);
	}

	void UpdateCoinsUI()
	{
		FindObjectOfType<UIManager>().UpdateCoins();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Enemy") && !tookDamage)
		{
			StartCoroutine(TookDamage());
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.CompareTag("Enemy") && !tookDamage)
		{
			StartCoroutine(TookDamage());
		}
		else if (other.gameObject.CompareTag("Coin"))
		{
			Destroy(other.gameObject);
			gameManager.coins += 1;
			UpdateCoinsUI();
		}
	}

	IEnumerator TookDamage()
	{
		tookDamage = true;
		health--;
		UpdateHealthUI();
		if(health <= 0)
		{
			isDead = true;
			anim.SetTrigger("Death");
			Invoke("ReloadScene", 2f);
		}
		else
		{
			Physics2D.IgnoreLayerCollision(9, 10);
			for (float i = 0; i < damageTime; i+= 0.2f)
			{
				GetComponent<SpriteRenderer>().enabled = false;
				yield return new WaitForSeconds(0.1f);
				GetComponent<SpriteRenderer>().enabled = true;
				yield return new WaitForSeconds(0.1f);
			}
			Physics2D.IgnoreLayerCollision(9, 10, false);
			tookDamage = false;
		}
	}

	void ReloadScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void SetHealthAndBombs(int life, int bomb)
	{
		health += life;
		if(health >= maxHealth)
		{
			health = maxHealth;
		}
		bombs += bomb;
		UpdateBombsUI();
		UpdateHealthUI();
	}
}
