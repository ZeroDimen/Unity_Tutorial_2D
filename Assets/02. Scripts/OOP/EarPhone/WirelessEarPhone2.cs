using UnityEngine;

public class WirelessEarPhone2 : WirelessEarPhone
{
    public bool isNoiseCancelling;
    
    private void Start()
    {
        name = "AirPod2";
        price = 150f;
        releaseYear = 2014;
        batterySize = 100f;
    }
    
    public virtual void NoiseCancelling()
    {
        isNoiseCancelling = !isNoiseCancelling;
        string msg = isNoiseCancelling ? "노이즈 캔슬링 켬" : "노이즈 캔슬링 끔";
        Debug.Log(msg);
    }
    
}