using UnityEngine;

// 캡슐화된 변수를 읽어보는 스크립트
public class Study_ExternalClass : MonoBehaviour
{
    public Study_Property study_property;

    private void Start()
    {
        int num1 = study_property.Number1; // private 필드에 접근
        study_property.Number1 = 10;
        
        int num2 = study_property.number2; // public 필드에 접근
        // study_property.number2 = 20; // 수정불가
        
        int num3 = study_property.number2; // public 필드에 접근
        // study_property.number3 = 20; // 내부에서 수정가능
    }
}