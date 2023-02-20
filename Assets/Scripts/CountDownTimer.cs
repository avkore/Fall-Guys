using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] private int countDownTime;
    [SerializeField] TMP_Text countDownDisplay;
    [SerializeField] Gamemanager gameManager;

    private void Start() {
        StartCoroutine(CountdownToStart());
    }
    IEnumerator CountdownToStart(){
        while(countDownTime > 0){
            countDownDisplay.text = countDownTime.ToString();

            yield return new WaitForSeconds(1f);

            countDownTime--;
        }

        countDownDisplay.text = "Go!";

        gameManager.BeginGame();

        yield return new WaitForSeconds(1f);

        countDownDisplay.gameObject.SetActive(false);
        gameManager.hasStarted = true;
    }
}
