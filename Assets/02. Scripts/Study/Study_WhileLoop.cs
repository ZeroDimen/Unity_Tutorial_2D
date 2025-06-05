using System;
using UnityEngine;

// While을 사용한 Loop문을 확인하는 스크립트
public class Study_WhileLoop : MonoBehaviour
{
   
    private void Start()
    {
        int count = 0;
        
        while (count < 10) // while (반복조건)
        {
            count++;
            Debug.Log($"현재 {count} 입니다");
        }
    }
}
