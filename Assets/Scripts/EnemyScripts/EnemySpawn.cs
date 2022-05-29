using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject prefab;
    public float repeatTime = 3f;
    public float rangeSpawnArea = 20f;

    private void Start()
    {
        InvokeRepeating("Spawn", 2f, repeatTime);
    }

   void Spawn()
    {
        transform.position = transform.position + Random.insideUnitSphere * rangeSpawnArea;
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
