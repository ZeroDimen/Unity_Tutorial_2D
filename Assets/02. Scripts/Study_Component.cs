using UnityEngine;

// 유니티 씬에 있는 오브젝트에 접근하는 스크립트
public class Study_Component : MonoBehaviour
{
    public GameObject Obj_A; // 유니티 Scene에 생성된 객체의 정보를 가져오기 위한 변수
    private GameObject Obj_B; 
    
    private string Obj_Name = "Renamed";

    private void Start()
    {
        Obj_B = GameObject.Find("Main Camera"); // 유니티 Scene에 생성된 객체 중 "Main Camera" 를 찾아 변수에 대입하는 코드

        Obj_A.name = Obj_Name;
        Obj_B.name = Obj_Name;
    }
}


