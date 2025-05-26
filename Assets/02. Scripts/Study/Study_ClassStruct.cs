using UnityEngine;

// 참조 타입과 값 타임 차이를 확인하는 스크립트
public class Study_Class 
{
    public int number;

    public Study_Class(int _number)
    {
        this.number = _number;
    }
}

public struct Study_Struct
{
    public int number;
    
    public Study_Struct(int _number)
    {
        this.number = _number;
    }
}
public class Study_ClassStruct : MonoBehaviour
{
    private void Start()
    {
        // 클래스는 같은 메모리 주소를 가리키는 것으로 값을 대입.
        Debug.Log("클래스 -------------------------------------------------");
        Study_Class c1 = new Study_Class(10);
        Study_Class c2 = c1;
        Debug.Log($"c1 : {c1.number} / c2 : {c2.number}");
        
        // 따라서 c1의 값이 바뀌면 같은 메모리 주소을 가리키는 c2도 값이 바뀜.
        c1.number = c1.number + 2;
        Debug.Log($"c1 : {c1.number} / c2 : {c2.number}");
        
        // 구조체는 s1, s2를 위한 메모리 주소를 생성 및 값 대입.
        Debug.Log("구조체 -------------------------------------------------");
        Study_Struct s1 = new Study_Struct(10);
        Study_Struct s2 = s1;
        Debug.Log($"s1 : {s1.number} / s2 : {s2.number}");
        
        // 따라서 s1의 값이 바뀌더라도 s2의 값은 바뀌지 않음.
        s1.number = s1.number + 2;
        Debug.Log($"s1 : {s1.number} / s2 : {s2.number}");
    }
}
