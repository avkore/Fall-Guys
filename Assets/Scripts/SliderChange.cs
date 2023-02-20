using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class SliderChange : MonoBehaviour
{
    public static int BotQuantity;
    
    [SerializeField] private TMP_Text playerQuantityText;
    // public float botQuantity;

    public void OnSliderChange(float value)
    {
        playerQuantityText.text = value.ToString();
        BotQuantity = (int) value;
    }
}