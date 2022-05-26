using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXMove : MonoBehaviour
{

	public LayerMask enemyLayer;
	public float radius = 0.5f;
	public float damageCount = 10f;
	public GameObject fxEffectToMove;

	private EnemyHealth enemyHealth;
	private bool collided;

	public float speed = 6f;

	void Start()
	{
		// find player and it's forward direction
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		transform.rotation = Quaternion.LookRotation(player.transform.forward);
	}

	void Update()
	{
		Move();
		CheckForDamage();
	}

	void Move()
	{
		// move the fx in the forward path
		transform.Translate(Vector3.forward * (speed * Time.deltaTime));
	}

	void CheckForDamage()
	{// for each hit at transform of radius that hits an enemy
		Collider[] hits = Physics.OverlapSphere(transform.position, radius, enemyLayer);

		foreach (Collider c in hits)
		{// for each hit at transform of radius that hits an enemy
			enemyHealth = c.gameObject.GetComponent<EnemyHealth>();
			collided = true;
		}

		if (collided)
		{
			enemyHealth.TakeDamage(damageCount);
			Vector3 temp = transform.position;
			temp.y += 2f;
			Instantiate(fxEffectToMove, temp, Quaternion.identity);
			Destroy(gameObject);
		}
	}

} // class
