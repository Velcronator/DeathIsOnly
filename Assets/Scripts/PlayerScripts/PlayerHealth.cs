using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

	public float health = 100f;

	private bool isShielded;

	private Animator animator;

	private Image health_Img;

	void Awake()
	{
		animator = GetComponent<Animator>();

		//health_Img = GameObject.Find("Health Icon").GetComponent<Image>();
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
			// for image
			health_Img.fillAmount = health / 100f;
			//
			if (health <= 0f)
			{
				animator.SetBool("Death", true);

				if (!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Death")
				   && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95)
				{
					// PLAYER DIED 
					// DESTROY PLAYER
					//Destroy(gameObject, 2f);
				}
			}
		}
	}

	public void HealPlayer(float healAmount)
	{
		health += healAmount;

		if (health > 100f)
			health = 100f;

		health_Img.fillAmount = health / 100f;
	}

} // class
