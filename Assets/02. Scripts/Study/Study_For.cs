using System.Collections.Generic;
using UnityEngine;

// For를 사용한 Loop문을 확인하는 스크립트
public class Study_For : MonoBehaviour
{
    public List<int> ListInt = new List<int>();
    void Start()
    {
        for (int i = 0; i < ListInt.Count; i++)
        {
            Debug.Log(ListInt[i]);
        }
    }
}
