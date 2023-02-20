using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    
    private void OnControllerColliderHit(Collision other) {
        if(other.gameObject.CompareTag("Player") && Gamemanager.Instance.hasStarted){
            StartCoroutine(StartDestroy());
        }
    }

    IEnumerator StartDestroy(){
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject, 3f);
    }
}
