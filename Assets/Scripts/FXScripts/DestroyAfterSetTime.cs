using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSetTime : MonoBehaviour
{
    public float timer = 6f;
    void Start()
    {
        Destroy(gameObject, timer); 
    }
}
