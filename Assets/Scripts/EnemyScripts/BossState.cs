using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Boss_State
{
	NONE,
	IDLE,
	PAUSE,
	ATTACK,
	DEATH
}


public class BossStateChecker : MonoBehaviour
{
	public float pauseIdleDistance = 15f;
	public float attackDistance = 3f;

	// intialize stuff
	private Transform playerTarget;
	private Boss_State boss_State = Boss_State.NONE;
	private float distanceToTarget;

	private EnemyHealth bossHealth;

	void Awake()
	{// finding stuff
		playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
		bossHealth = GetComponent<EnemyHealth>();
	}

	void Update()
	{
		SetState();
	}

	void SetState()
	{
		distanceToTarget = Vector3.Distance(transform.position, playerTarget.position);
		// based on distance from the play we shall set a state
		if (boss_State != Boss_State.DEATH)
		{
			if ((distanceToTarget > attackDistance) && (distanceToTarget <= pauseIdleDistance))
			{	// if not too close and not too far
				boss_State = Boss_State.PAUSE;
			}
			else if (distanceToTarget > pauseIdleDistance)
			{	// miles away
				boss_State = Boss_State.IDLE;
			}
			else if (distanceToTarget <= attackDistance)
			{	// too close for comfort
				boss_State = Boss_State.ATTACK;
			}
			else
			{	// everthing else
				boss_State = Boss_State.NONE;
			}

			if (bossHealth.health <= 0f)
			{	// The boss is dead, long live the boss
				boss_State = Boss_State.DEATH;
			}

		}

	}

	public Boss_State BossState
	{
		get { return boss_State; }
		set { boss_State = value; }
	}

} // class
