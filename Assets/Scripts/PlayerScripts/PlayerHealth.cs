using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	public GameObject lostMenuUI;

	public float health = 100f;

	private bool isShielded = false;

	private Animator animator;

	private Image health_Img;

	void Awake()
	{
		animator = GetComponent<Animator>();
		health_Img = GameObject.Find("HealthIcon").GetComponent<Image>();
	}

	public bool Shielded
	{// public setters and getters
		get { return isShielded; }
		set { isShielded = value; }
	}

	public void TakeDamage(float amount)
	{
		if (!isShielded)
		{// if shielded then nothing happens

			health -= amount;
			health_Img.fillAmount = health / 100f;

			if (health <= 0f)
			{
				FindObjectOfType<AudioManager>().Play("PlayerDeath");
				animator.SetBool("Death", true);
				lostMenuUI.SetActive(true);
				Destroy(gameObject, 1f);
				Time.timeScale = 0f;
			}
		}
	}

	public void HealPlayer(float healAmount)
	{
		health += healAmount;

		if (health > 100f) { health = 100f; }
		health_Img.fillAmount = health / 100f;
	}

} // class
