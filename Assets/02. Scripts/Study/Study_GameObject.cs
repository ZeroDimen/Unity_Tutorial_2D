using System;
using UnityEngine;


public class Study_GameObject : MonoBehaviour
{
    public GameObject Prefab;
    public GameObject Dest_Obj;
    
    public Vector3 Pos;
    public Quaternion Rot;
    private void Awake() // Start 함수보다 빨리 호출됨
    {
        CreateMonster("Monster", 2);
    }

    private void CreateMonster(string _name = "Slime", float n = 0) // 프리펩을 통한 게임 오브젝트 생성 함수
    {
        Debug.Log("Spowned");
        // Instantiate(Prefab,Pos,Rot).name = "Monster"
        GameObject obj = Instantiate(Prefab,Pos,Rot);
        obj.name = _name;
        
        // Hierarchy : 계층 구조 확인 가능 Winodow
        // Transform : 계층 구조로 접근할 수 있는 Component
        // obj.GetChild() 가 아니라 obj.transform.GetChild() 인 이유는 Getchild() 메소드가 Trensform 컴포넌트에 있기 때문

        
        // Debug.Log($"캐릭터의 자식 오브젝트 수 : {obj.transform.childCount}");
        // Debug.Log($"캐릭터의 첫번째 자식 오브젝트의 이름 : {obj.transform.GetChild(0).name}");
        // Debug.Log($"캐릭터의 마지막 자식 오브젝트의 이름 : {obj.transform.GetChild(obj.transform.childCount - 1).name}");

        // 지역 변수로 만들어 가독성 증가, 지역 변수는 함수가 종료되면 지역 변수 삭제(메모리 해제)
        Transform Obj_Trans = obj.transform; 
        int count = Obj_Trans.childCount;
        
        Debug.Log($"캐릭터의 자식 오브젝트 수 : {count}");
        Debug.Log($"캐릭터의 첫번째 자식 오브젝트의 이름 : {Obj_Trans.GetChild(0).name}");
        Debug.Log($"캐릭터의 마지막 자식 오브젝트의 이름 : {Obj_Trans.GetChild(count - 1).name}");

    }
    
}
