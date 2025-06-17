using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Portal_Pad : MonoBehaviour
{
    private string inputNum;
    public TextMeshProUGUI tpString;


    public void OnEnable()
    {
        inputNum = "";
    }

    public void TouchnumPad(string numString) // numPad에서 버튼 입력시 호출 되는 함수
    {
        if (numString == "Enter")
        {
            
        }
        else if (numString == "Delete")
        {
            inputNum = "";
        }
        else
        {
            inputNum += numString;
        }
        
        tpString.text = $"TP : {inputNum}";
    }
}

