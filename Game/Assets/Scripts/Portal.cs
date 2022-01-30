using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public int requiredNumBananas = 9;
    public GameObject destinationPortal;
    private Animator _thisAnimator, _destAnimator;

    private void Awake()
    {
        _thisAnimator = GetComponent<Animator>();
        _destAnimator = destinationPortal.GetComponent<Animator>();
    }

    private void Update()
    {
        ActivateIfBananas();
    }

    private void ActivateIfBananas()
    {
        if (Inventory.instance.HowManyBananas() == requiredNumBananas)
        {
            _thisAnimator.SetTrigger("On");
        }
    }

    private void DeactiveIfUsed()
    {
        _thisAnimator.SetTrigger("Off");
    }

    public void TeleportIfBananas(int currentNumBananas)
    {
        // TODO
    }
}
