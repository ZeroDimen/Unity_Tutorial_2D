using UnityEngine;

// Generic을 사용하기 위한 타입 <T> 함수를 구현한 스크립트

public class Study_Generic : MonoBehaviour
{
    private void Start()
    {
        int number_a = 1;
        int number_b = 2;

        char c_a = 'A';
        char c_b = 'B';

        string str_a = "Hello";
        string str_b = "World";
        
        Swap<int>(ref number_a,ref number_b);
        Swap<char>(ref c_a, ref c_b);
        Swap<string>(ref str_a, ref str_b);
    }


    public void Swap<T>(ref T a, ref T b)
    {
        //  <T> 타입을 런타임에 결정하는 것이 아닌 컴파일 타임에서를 결정 따라서 때문에 성능저하 X
        Debug.Log($"입력 / a : {a} , b : {b}");
        T temp;
        temp = a;
        a = b;
        b = temp;
        Debug.Log($"출력 / a : {a} , b : {b}");
    }
}
