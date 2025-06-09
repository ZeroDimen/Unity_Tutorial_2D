using UnityEngine;

// Invoke를 사용한 함수를 반복호출하는 스크립트
public class Study_invoke : MonoBehaviour
{
    private void Start()
    {
        // Invoke(methodName,Time); methodName 함수를 Time초 마다 반복 호출
        Invoke("method",5f); 
        
        // InvokeRepeating(methodName,Time, repeatRate); Time초 동안 대기후 methodName 함수를 repeatRate 마다 반복 호출
        // InvokeRepeating("method", 3f, 4f);
        
        CancelInvoke("method"); // 반복 호출 종료
    }

    private void method()
    {
        Debug.Log("Invoked");
    }
}
