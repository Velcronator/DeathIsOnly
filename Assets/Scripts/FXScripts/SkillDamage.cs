using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDamage : MonoBehaviour
{

	public LayerMask enemyLayer;
	public float radius = 0.5f;
	public float damageCount = 10f;

	private EnemyHealth enemyHealth;
	private bool collided;

	void Update()
	{
		// if hits are within the radius
		Collider[] hits = Physics.OverlapSphere(transform.position, radius, enemyLayer);

		foreach (Collider c in hits)
		{
			/*			if (c.isTrigger)
							continue;
			//useful if the object has a trigger collider.
			// not needed here
			*/


			enemyHealth = c.gameObject.GetComponent<EnemyHealth>();
			collided = true;
			// it has collided
		}

		// if previous bool is true then deal damage
		if (collided)
		{
			enemyHealth.TakeDamage(damageCount);
			enabled = false;
		}
	}


} // class