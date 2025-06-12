using UnityEngine;

// 키패드 입력을 관리하는 스크립트
public class Door_NumberKeyPad : MonoBehaviour
{
    public Animator DoorAni;
    public string Password;
    public string InputNumber;

    public void OnInputNumber(string num_String)
    {
        InputNumber += num_String;
        Debug.Log($"{num_String} 입력 -> {InputNumber}");
    }

    public void OnCheckNumber()
    {
        if (InputNumber == Password)
        {
            Debug.Log($"{InputNumber}는 정답입니다");
            DoorAni.SetTrigger("IsFront");
            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log($"{InputNumber}는 오답입니다");
            InputNumber = "";
        }
    }
}
