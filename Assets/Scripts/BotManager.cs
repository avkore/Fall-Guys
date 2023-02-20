using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BotManager : MonoBehaviour
{
    [SerializeField] private GameObject bots;
    
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            for (int i = 0; i < SliderChange.BotQuantity; i++)
            {
                bots.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    private void Awake()
    {
    }
}
