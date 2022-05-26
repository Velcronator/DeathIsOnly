using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
	// stuff to assign
	public float health = 100f;
	public Image health_Img;

	// damage
	public void TakeDamage(float amount)
	{
		health -= amount;
		print("health is: " + health);
		//health_Img.fillAmount = health / 100f;

		if (health <= 0)
		{

		}
	}


} // class