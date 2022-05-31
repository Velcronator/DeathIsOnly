using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowthePlayer : MonoBehaviour
{
	public Transform temp;
	GameObject player;

	void Start()
	{
		// find player
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		Move();
	}

	void Move()
	{
		// move the fx in the forward path
		temp.position = player.transform.position;
		transform.position = temp.position;
	}
}
