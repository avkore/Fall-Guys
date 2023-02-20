using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Propeller : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;
    void Update()
    {
        transform.Rotate(0, 90 * Time.deltaTime * rotationSpeed, 0);
        
    }
}
