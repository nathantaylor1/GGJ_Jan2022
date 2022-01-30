using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumBananas : MonoBehaviour
{
    [SerializeField] private int numBananas = 1;

    public int GetNumBananas()
    {
        return numBananas;
    }
}
