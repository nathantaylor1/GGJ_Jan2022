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


    private static int _numBananas = 0;

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
        bananaCounterDisplay.text = _numBananas.ToString("00") + "/" + TotalNumBananas.ToString("00");
    }

    public int HowManyBananas()
    {
        return _numBananas;
    }

    private int TotalNumBananas = 15;
    public void SetNumBananas(int num)
    {
        TotalNumBananas = num;
        UpdateBananaDisplayText();
    }
}
