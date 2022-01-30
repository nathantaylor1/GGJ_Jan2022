using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int howManyBananas = 15;
    public Text YouWinDisplay;

    private void Start()
    {
        Inventory.instance.SetNumBananas(howManyBananas);
    }

    void Update()
    {
        print(Inventory.instance.HowManyBananas());
        if (Inventory.instance.HowManyBananas() == howManyBananas)
        {
            YouWinDisplay.gameObject.SetActive(true);
        }
    }
}
