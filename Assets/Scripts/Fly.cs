using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fly : MonoBehaviour
{
    public float moveDistance = 5f;
    public float moveDuration = 1f;
    void Start()
    {
        transform.DOLocalMoveY(transform.localPosition.y + moveDistance, moveDuration).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
