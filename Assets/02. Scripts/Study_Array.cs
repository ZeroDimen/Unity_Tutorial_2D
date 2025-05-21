using System.Collections.Generic;
using UnityEngine;

// 접근 제한자를 확인하고 정적 배열과 동적 배열을 비교하는 스크립트
public class Study_Array : MonoBehaviour
{
    // 접근 제한자
    // public : 다른 클래스, 유니티 에디터에서 접근 가능
    // private : 자신 클래스(this)에서만 접근 가능, 기본값
    
    private int Max = 5; // private 필드
    
    public int _PublicNum = 1;
    private int _PrivateNum;
    [SerializeField] private int _PublicNum2; // 자신 클래스에서만 접근 가능하지만 유니티 에디터에서 접근 가능, (필드)직렬화
    
    
    // 정적 배열 : 같은 타입의 데이터를 연속적인 메모리 공간에 저장하여 Index로 접근하는 자료구조 (크기가 변동 X, 속도가 빠름)
    private int[] Array_A = new int[5];  //선언이 없을 경우 0으로 초기화 됨
    
    private int[] Array_B = new int[5] { 1, 2, 3, 4, 5 }; 
    
    public int[] Array_C = new int[5] { 1, 2, 3, 4, 5 }; // 코드 상으로는 수정 불가, 유니티 에디터 상으로는 순서, 값 변경 가능(에디터가 우선 순위 테스트용)

    // 동적 배열 : 크기가 변할 수 있는 배열로, 데이터를 더하거나 빼는 것이 가능한 자료구조
    List<int> List_A = new List<int>() {1,2,3,4,5}; 
    
    
    private void Start()
    {
        Array_Message();
        List_Message();
    }

    private void Array_Message() // 정적 배열 호출 함수
    {
        Debug.Log($"Array_A의 길이 : {Array_A.Length} -------------");
        for (int i = 0; i < Array_A.Length; i++)
        {
            Debug.Log($"Array_A {i + 1}번 값 : {Array_A[i]}");
        }

        Debug.Log($"Array_B의 길이 : {Array_B.Length} -------------");
        for (int i = 0; i < Array_B.Length; i++)
        {
            Debug.Log($"Array_B {i + 1}번 값 : {Array_B[i]}");
        }
        //Debug.Log($"Array 6번 값 : {Array_B[5]}"); // indexOutOfRange 오류

        Debug.Log($"Array_C의 길이 : {Array_C.Length} -------------");
        for (int i = 0; i < Array_C.Length; i++)
        {
            Debug.Log($"Array_C {i + 1}번 값 : {Array_C[i]}");
        }
    }

    private void List_Message() // 동적 배열 호출 함수
    {
        List_A.Add(10);
        List_A.Add(20);
        List_A.Add(30);
        List_A.Add(40);
        List_A.Add(50);

        Debug.Log($"List_A의 길이 : {List_A.Count} -------------------");
        Debug.Log($"List_A의 마지막 데이터 수 : {List_A[List_A.Count - 1]}");
        for (int i = 0; i < List_A.Count; i++)
        {
            Debug.Log($"List_A {i+1}번 값 : {List_A[i]}");
        }
    }
}
