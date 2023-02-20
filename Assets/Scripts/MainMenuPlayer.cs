using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPlayer : MonoBehaviour
{
    private Animator anim;
    private void Start(){
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Idle")){
                anim.SetInteger("AnimationIndex", Random.Range(1, 8));
                anim.SetTrigger("RandomAnimation");
        }
    }
}
