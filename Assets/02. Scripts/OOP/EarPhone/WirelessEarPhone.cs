using System;
using UnityEngine;

public class WirelessEarPhone : EarPhone
{
    public float batterySize;
    public bool isWirelessCharged;

    private void Start()
    {
        name = "AirPod1";
        price = 100f;
        releaseYear = 2007;
        batterySize = 70f;
    }

    public void Charged()
    {
        // if (isWireLessCharged)
        //     Debug.Log("무선충전");
        // else
        // {
        //     Debug.Log("유선충전");
        // }
        string msg = isWirelessCharged ? "무선충전" : "유선충전";
        Debug.Log(msg);
    }

}