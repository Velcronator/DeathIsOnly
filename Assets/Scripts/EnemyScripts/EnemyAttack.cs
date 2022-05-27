using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

	public float enemyHitdamageAmount = 10f;
	public float swordSlashdamageAmount = 20f;


	private Transform playerTarget;
	private PlayerHealth playerHealth;

	void Awake()
	{
		playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
		// find stuff
		playerHealth = playerTarget.GetComponent<PlayerHealth>();
	}


	void EnemyHit()
    {
		playerHealth.TakeDamage(enemyHitdamageAmount);
	}

	void EnemySwordSlash()
    {
		playerHealth.TakeDamage(swordSlashdamageAmount);
	}

	//bool CheckIfAttacking()
	//{
	//	bool isAttacking = false;
		
	//	if (!animator.IsInTransition(0) && (animator.GetCurrentAnimatorStateInfo(0).IsName("Atk1") ||
	//	   animator.GetCurrentAnimatorStateInfo(0).IsName("Atk2")))
	//	{
	//		if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= animationPlayed)
	//		{
	//			isAttacking = true;
	//			finishedAttack = false;
	//		}
	//	}
	//	return isAttacking;
	//}

	//void DealDamage(bool isAttacking)
	//{
	//	if (isAttacking)
	//	{
	//		playerHealth.TakeDamage(damageAmount);

	//		if (Vector3.Distance(transform.position, playerTarget.position) <= damageDistance)
	//		{	// if is attacking is in damage distance range, player takes damage in playerHealth script
	//			playerHealth.TakeDamage(damageAmount);
	//		}
	//	}
	//}

} // class