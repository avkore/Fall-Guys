using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    [SerializeField] private Gamemanager gameManager;
    private Vector3 targetPos;
    private Animator anim;
    private bool generated;

    [SerializeField] private float speed;
    [SerializeField] private float minX = -4.75f;
    [SerializeField] private float maxX = 2.1f;
    [SerializeField] private float minZ = -2.95f;
    [SerializeField] private float maxZ = 5.1f;
    

    public string[] collisionTags; //  What are the GO tags that will act as colliders that trigger a

    //  direction change? Tags like for walls, room objects, etc.s


    float step = Mathf.PI / 60;
    float timeVar = 0;
    float rotationRange = 90; //  How far should the object rotate to find a new direction?
    float baseDirection = 0;

    Vector3 randomDirection; // Random, constantly changing direction from a narrow range for natural motion

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        float x = transform.position.x;
        float z = transform.position.z;
        x = Mathf.Clamp(x, minX, maxX);
        z = Mathf.Clamp(x, minZ, maxZ);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
        
        if (gameManager.hasStarted == true)
        {
            anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
            randomDirection =
                new Vector3(0, Mathf.Sin(timeVar) * (rotationRange / 3) + baseDirection,
                    0); //   Moving at random angles 
            timeVar += step;
            GetComponent<Rigidbody>().AddForce(transform.forward * speed);
            transform.Rotate(randomDirection * Time.deltaTime * 2.0f);
        }
        else
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !generated)
            {
                anim.SetInteger("AnimationIndex", Random.Range(1, 8));
                anim.SetTrigger("RandomAnimation");
                generated = true;
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == collisionTags[0])
        {
            baseDirection = baseDirection + Random.Range(-30, 30); // Switch to a new direction on collision
        }
    }
}
