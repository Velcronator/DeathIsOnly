using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShield : MonoBehaviour
{

	private PlayerHealth playerHealth;

	void Awake()
	{	// get players health
		playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
	}

	void OnEnable()
	{	// change shielded variable in player health
		playerHealth.Shielded = true;
	}

	void OnDisable()
	{	// change shielded variable in player health
		playerHealth.Shielded = false;
	}


} // class