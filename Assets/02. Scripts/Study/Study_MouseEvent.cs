using UnityEngine;

// 마우스 입력 함수 스크립트
public class Study_MouseEvent : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 입력 버튼 눌렀을때
        {
            Debug.Log("GetMouseButtonDown");
        }

        if (Input.GetMouseButton(0)) // 마우스 버튼 입력 유지
        {
            Debug.Log("GetMouseButton");
        }

        if (Input.GetMouseButtonUp(0)) // 마우스 입력 버튼 땠을때
        {
            Debug.Log("GetMouseButtonUp");
        }
    }
}
