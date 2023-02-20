using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingObstacle : MonoBehaviour
{
    public float speed = 1.0f;
    public float distance = 5.0f;
    private float startZ;
    
    void Start()
    {
        startZ = transform.position.z;
    }

    void Update()
    {
        float newZ = startZ + Mathf.PingPong(Time.time * speed, distance);
        transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
    }
}
