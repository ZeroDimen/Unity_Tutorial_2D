using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Portal_Pad : MonoBehaviour
{
    private string inputNum;
    public TextMeshProUGUI tpString;
    
    [SerializeField]
    private RawImage cctvImage;
    [SerializeField]
    private RenderTexture[] cctvTextures;
    
    public void OnEnable()
    {
        tpString.text = $"TP : None";
        inputNum = "";
    }

    public void CCTV(int touchNum)
    {
        if (touchNum > 0 && touchNum < cctvTextures.Length)
        {
            cctvImage.texture = cctvTextures[touchNum - 1];
        }
        else
        {
            Debug.Log("CCTV ERROR");
        }
    }

    public void TouchnumPad(string numString) // numPad에서 버튼 입력시 호출 되는 함수
    {
        if (numString == "Enter") // Enter 버튼 입력시
        {
            if (inputNum != "")
            {
                CCTV(int.Parse(inputNum));
                inputNum = "";
            }
        }
        else if (numString == "Delete") // Delete 버튼 입력시
        {
            inputNum = "";
        }
        else
        {
            inputNum += numString;
            if (inputNum == "0")
            {
                inputNum = "";
            }
        }
        
        tpString.text = $"TP : {inputNum}";
    }
}

