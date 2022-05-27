using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
	// Faded images
	public Image fillWaitImage_1;
	public Image fillWaitImage_2;
	public Image fillWaitImage_3;
	public Image fillWaitImage_4;
	public Image fillWaitImage_5;
	public Image fillWaitImage_6;

	// Array of faded images
	private int[] fadeImages = new int[] { 0, 0, 0, 0, 0, 0 };

	private Animator animator;
	private bool canAttack = true;

	// To get position from script
	private PlayerMove playerMove;
	private float lookSpeed = 15f; 

	void Awake()
	{
		animator = GetComponent<Animator>();
		playerMove = GetComponent<PlayerMove>();
	}

	void Update()
	{	// if not in animation transition and in stand blend tree
		if (!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
		{
			canAttack = true;
		}
		else
		{
			canAttack = false;
		}
		CheckToFade();
		CheckInput();
	}

	void CheckInput()
	{
		// No attack animation 
		if (animator.GetInteger("Attack") == 0)
		{
			playerMove.FinishedMovement = false;
			// check if no movement other than Stand Blend tree
			if (!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
			{
				playerMove.FinishedMovement = true;
			}
		}

		// Check for keys down to activate animations
		if (Input.GetKeyDown(KeyCode.A))
		{
			playerMove.TargetPosition = transform.position;

			// fadeImages[0] meaning image thats at index 0 e.g. the first image
			if (playerMove.FinishedMovement && fadeImages[0] != 1 && canAttack)
			{
				fadeImages[0] = 1;
				animator.SetInteger("Attack", 1);
			}
		}
		else if (Input.GetKeyDown(KeyCode.S))
		{
			playerMove.TargetPosition = transform.position;

			if (playerMove.FinishedMovement && fadeImages[1] != 1 && canAttack)
			{
				fadeImages[1] = 1;
				animator.SetInteger("Attack", 2);
			}
		}
		else if (Input.GetKeyDown(KeyCode.D))
		{
			playerMove.TargetPosition = transform.position;

			if (playerMove.FinishedMovement && fadeImages[2] != 1 && canAttack)
			{
				fadeImages[2] = 1;
				animator.SetInteger("Attack", 3);
			}
		}
		else if (Input.GetKeyDown(KeyCode.Q))
		{
			playerMove.TargetPosition = transform.position;

			if (playerMove.FinishedMovement && fadeImages[3] != 1 && canAttack)
			{
				fadeImages[3] = 1;
				animator.SetInteger("Attack", 4);
			}
		}
		else if (Input.GetKeyDown(KeyCode.W))
		{
			playerMove.TargetPosition = transform.position;

			if (playerMove.FinishedMovement && fadeImages[4] != 1 && canAttack)
			{
				fadeImages[4] = 1;
				animator.SetInteger("Attack", 5);
			}
		}
		else if (Input.GetMouseButtonDown(1))
		{	// Space bar
			playerMove.TargetPosition = transform.position;

			if (playerMove.FinishedMovement && fadeImages[5] != 1 && canAttack)
			{
				fadeImages[5] = 1;
				animator.SetInteger("Attack", 6);
			}
		}
		else
		{	// nothing happening
			animator.SetInteger("Attack", 0);
		}

		if (Input.GetKey(KeyCode.E))
		{	// Stop look hey what's that sound everybody look around
			Vector3 targetPos = Vector3.zero;

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastHit;

			if (Physics.Raycast(ray, out raycastHit))
			{
				targetPos = new Vector3(raycastHit.point.x, transform.position.y, raycastHit.point.z);
			}

			transform.rotation = Quaternion.Slerp(transform.rotation,
				Quaternion.LookRotation(targetPos - transform.position), lookSpeed * Time.deltaTime);

		}

	} // check input

	void CheckToFade()
	{	// Fade and wait
		if (fadeImages[0] == 1)
		{
			if (FadeAndWait(fillWaitImage_1, 1.0f))
			{
				fadeImages[0] = 0;
			}
		}

		if (fadeImages[1] == 1)
		{
			if (FadeAndWait(fillWaitImage_2, 0.7f))
			{
				fadeImages[1] = 0;
			}
		}

		if (fadeImages[2] == 1)
		{
			if (FadeAndWait(fillWaitImage_3, 0.1f))
			{
				fadeImages[2] = 0;
			}
		}

		if (fadeImages[3] == 1)
		{
			if (FadeAndWait(fillWaitImage_4, 0.2f))
			{
				fadeImages[3] = 0;
			}
		}

		if (fadeImages[4] == 1)
		{
			if (FadeAndWait(fillWaitImage_5, 0.3f))
			{
				fadeImages[4] = 0;
			}
		}

		if (fadeImages[5] == 1)
		{
			if (FadeAndWait(fillWaitImage_6, 0.08f))
			{
				fadeImages[5] = 0;
			}
		}

	}

	bool FadeAndWait(Image fadeImg, float fadeTime)
	{	// Image and the fade time for each image passed the lower the fade amount the quicker it resets
		bool faded = false;

		if (fadeImg == null)
			return faded;// no image so return faded

		if (!fadeImg.gameObject.activeInHierarchy)
		{	
			fadeImg.gameObject.SetActive(true);
			fadeImg.fillAmount = 1f;
		}// if not active then image is faded that is fill amount is 1 in inspector

		fadeImg.fillAmount -= fadeTime * Time.deltaTime;

		if (fadeImg.fillAmount <= 0.0f)
		{
			fadeImg.gameObject.SetActive(false);
			faded = true;
		}// done with faded

		return faded;
	}

} // class
