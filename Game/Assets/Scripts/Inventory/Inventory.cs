using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public Text bananaCounterDisplay;
    
    private void Awake()
    {
        instance = this;
        UpdateBananaDisplayText();
    }


    private int _numBananas = 0;

    public void AddBananas(int number)
    {
        _numBananas += number;
        UpdateBananaDisplayText();
    }

    public void RemoveBananas(int number)
    {
        _numBananas -= number;
        UpdateBananaDisplayText();
    }

    public void UpdateBananaDisplayText()
    {
        bananaCounterDisplay.text = _numBananas.ToString("000");
    }
}
