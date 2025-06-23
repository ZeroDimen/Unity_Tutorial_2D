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
    private Camera[] cctvCameras;

    private bool isWarp;
    private Camera camera;
    public Transform Player; // 개선 해야할지도
    
    public void OnEnable()
    {
        tpString.text = $"TP : None";
        inputNum = "";
        isWarp = false;
    }

    public void CCTV(int touchNum)
    {
        if (touchNum > 0 && touchNum <= cctvCameras.Length)
        {
            if (!isWarp) // 같은 번호 2번 입력시 위치이동
            {
                cctvImage.texture = cctvCameras[touchNum - 1].targetTexture;
                isWarp = true;
            }
            else
            {
                Player.position =  cctvCameras[touchNum - 1].transform.position;
            }
        }
        else
        {
            Debug.Log("CCTV ERROR");
            isWarp = false;
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

