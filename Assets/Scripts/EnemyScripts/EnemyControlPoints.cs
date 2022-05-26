using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControlPoints : MonoBehaviour
{
	private float distanceToPoint =0.5f;
	public Transform[] walkPoints;
	private int walk_Index = 0;

	private Transform playerTarget;

	private Animator anim;
	private NavMeshAgent navAgent;

	private float walk_Distance = 8f;
	private float attack_Distance = 2f;

	private float currentAttackTime;
	private float waitAttackTime = 1f;

	private Vector3 nextDestination;

	private EnemyHealth enemyHealth;

	void Awake()
	{
		playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
		anim = GetComponent<Animator>();
		navAgent = GetComponent<NavMeshAgent>();
		enemyHealth = GetComponent<EnemyHealth>();
	}

	void Update()
	{
		if (enemyHealth.health > 0)
		{	// carry on
			MoveAndAttack();
		}
		else
		{	// death
			anim.SetBool("Death", true);
			navAgent.enabled = false;
			if (!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Death")
				&& anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95f)
			{
				Destroy(gameObject, 2f);
			}
		}
	}

	void MoveAndAttack()
	{
		float distance = Vector3.Distance(transform.position, playerTarget.position);

		if (distance > walk_Distance)
		{

			if (navAgent.remainingDistance <= distanceToPoint)
			{// getting close to point
				
				navAgent.isStopped = false;
				// walking and attack is set to false
				anim.SetBool("Walk", true);
				anim.SetBool("Run", false);
				anim.SetInteger("Atk", 0);
				// go to next point
				nextDestination = walkPoints[walk_Index].position;
				navAgent.SetDestination(nextDestination);
				// next walk point
				if (walk_Index == walkPoints.Length - 1)
				{
					walk_Index = 0;
				}
				else
				{
					walk_Index++;
				}

			}

		}
		else
		{

			if (distance > attack_Distance)
			{

				navAgent.isStopped = false;
				// player seen run 
				anim.SetBool("Walk", false);
				anim.SetBool("Run", true);
				anim.SetInteger("Atk", 0);

				navAgent.SetDestination(playerTarget.position);

			}
			else
			{
				// player seen and within attack range
				navAgent.isStopped = true;

				anim.SetBool("Run", false);
				// go to player
				Vector3 targetPosition = new Vector3(playerTarget.position.x, transform.position.y,
					playerTarget.position.z);
				// look at player
				transform.rotation = Quaternion.Slerp(transform.rotation,
					Quaternion.LookRotation(targetPosition - transform.position), 5f * Time.deltaTime);
				// Attack random attak
				if (currentAttackTime >= waitAttackTime)
				{
					int atkRange = Random.Range(1, 3);
					anim.SetInteger("Atk", atkRange);
					currentAttackTime = 0f;
				}
				else
				{// wait for next attack so set it to no attack
					anim.SetInteger("Atk", 0);
					currentAttackTime += Time.deltaTime;
				}

			}
		}
	}

} // class