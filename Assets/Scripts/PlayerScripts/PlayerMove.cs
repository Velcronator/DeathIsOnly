using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

	private Animator animator;
	private CharacterController characterController;
	private CollisionFlags collisionFlags = CollisionFlags.None;

	private float moveSpeed = 5f;
	private bool canPlayerMove;
	private bool finishedMovement = true;
	private float playerRotationSpeed = 15.0f;

	private Vector3 targetPosition = Vector3.zero;
	private Vector3 playerMove = Vector3.zero;

	private float playerToPointDistance;

	private float gravity = 9.8f; // due to no rigid body
	private float height; // above ground

	void Awake()
	{
		animator = GetComponent<Animator>();
		characterController = GetComponent<CharacterController>();
	}

	void Update()
	{
		CalculateHeight();
		CheckIfFinishedMovement();
	}

	bool IsGrounded()
	{
		return collisionFlags == CollisionFlags.CollidedBelow ? true : false;
	}

	void CalculateHeight()
	{
		if (IsGrounded()) { height = 0f; } // if on the ground then height is zero
		else { height -= gravity * Time.deltaTime; } // what goes up blah
	}

	void CheckIfFinishedMovement()
	{
		// Still on the move?
		if (!finishedMovement)
		{	// IsInTransition Zero refers to layer in animation states
			if (!animator.IsInTransition(0) && !animator.GetCurrentAnimatorStateInfo(0).IsName("Stand")
				&& animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
			{
				//if animator isn't transitioning and Standing or idle or close to the end of animation 0.8f is close to the end
				finishedMovement = true;
			}
		}
		else
		{	// Move player
			MoveThePlayer();
			playerMove.y = height * Time.deltaTime;
			collisionFlags = characterController.Move(playerMove);
		}
	}

	void MoveThePlayer()
	{
		if (Input.GetMouseButtonDown(0))// 0 is left mouse button
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//Ray 
			RaycastHit raycastHit;//where it hits

			if (Physics.Raycast(ray, out raycastHit))//out for conversion
			{
				if (raycastHit.collider is TerrainCollider)// was it a terrain that was hit
				{
					playerToPointDistance = Vector3.Distance(transform.position, raycastHit.point);//Distance between two points
					if (playerToPointDistance >= 1.0f)//doesn't move if too close
					{
						canPlayerMove = true;//player can move
						targetPosition = raycastHit.point; // target position is the collision point
					}
				}
			}
		} // if mouse button down

		if (canPlayerMove)
		{   // are we there yet
			animator.SetFloat("Run", 1.0f);// speed to set the run animation on.
			Vector3 targetTemp = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);

			if(targetTemp != Vector3.zero)
            {
				transform.rotation = Quaternion.Slerp(transform.rotation,
					Quaternion.LookRotation(targetTemp - transform.position),
					playerRotationSpeed * Time.deltaTime); // Rotate the player to the position
			}
			playerMove = transform.forward * moveSpeed * Time.deltaTime;
			if (Vector3.Distance(transform.position, targetPosition) <= 0.1f)// look kids we have arrived
			{
				canPlayerMove = false;
			}
		}
		else
		{
			playerMove.Set(0f, 0f, 0f);
			animator.SetFloat("Run", 0.0f);
		}
	}

	public bool FinishedMovement
	{
		get { return finishedMovement; }
		set { finishedMovement = value; }
	}

	public Vector3 TargetPosition
	{
		get { return targetPosition; }
		set { targetPosition = value; }
	}

}
/*
 * End of PlayerMove Class
 */