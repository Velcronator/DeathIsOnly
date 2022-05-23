using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float follow_Height = 14f; // above the player
	public float follow_Distance = 20f; // Distance from player

	private Transform player;

	private float target_Height;
	private float current_Height;
	private float current_Rotation;
	private float smoothing_Lerp_Factor = 0.9f;

	void Awake () { // Find the player
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update () {
		target_Height = player.position.y + follow_Height; 
		// Where the camera should be
		current_Rotation = transform.eulerAngles.y; 
		// Y Rotation
		current_Height = Mathf.Lerp (transform.position.y, target_Height, smoothing_Lerp_Factor * Time.deltaTime);
		// Smoothing between current to target height taking Lerp time
		Quaternion euler = Quaternion.Euler (0f, current_Rotation, 0f);
		// Rotation of Y side pan basically
		Vector3 target_Position = player.position - (euler * Vector3.forward) * follow_Distance;
		// Make the camera face the player at a certain distance
		target_Position.y = current_Height;

		transform.position = target_Position;
		transform.LookAt (player);
	}

} // class






































