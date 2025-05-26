using UnityEngine;

// 유니티 엔진에서의 이벤트 함수의 호출 순서를 확인하기 위한 스크립트
public class Study_UnityEvent : MonoBehaviour
{
    private void Awake() // 유니티 엔진 시작시 Start()보다 먼저 호출, 두번 호출되지 않음
    {
        Debug.Log("Awake");
    }

    private void Start() // 유니티 엔진 시작시 호출, 두번 호출되지 않음
    {
        Debug.Log("Start");
    }

    private void OnEnable() // 활성화가 될때마다 호출
    {
        Debug.Log("OnEnable");
    }
    private void OnDisable() // 비활성화가 될때마다 호출
    {
        Debug.Log("OnDisable");
    }
}
