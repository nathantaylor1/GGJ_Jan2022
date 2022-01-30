using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaTimer : MonoBehaviour
{
    public float timeToLoseBanana = 5.0f;
    public static BananaTimer instance;
    private bool _runTimer = false;

    private void Awake()
    {
        instance = this;
    }

    public void BeginTimer()
    {
        _runTimer = true;
        StartCoroutine(CO_RunTimer());
    }

    public void EndTimer()
    {
        _runTimer = false;
    }

    private float _myDeltaTime = 0.0f, _timeIncrement = 0.2f;
    private IEnumerator CO_RunTimer()
    {
        
        while (_runTimer)
        {
            yield return new WaitForSeconds(_timeIncrement);
            _myDeltaTime += _timeIncrement;
            if (_myDeltaTime >= timeToLoseBanana)
            {
                Inventory.instance.RemoveBananas(1);
            }
        }
    }
}
