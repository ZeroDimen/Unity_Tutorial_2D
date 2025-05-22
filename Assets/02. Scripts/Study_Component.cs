using UnityEngine;

// 유니티 Scene에 있는 오브젝트에 접근하는 스크립트
public class Study_Component : MonoBehaviour
{
    public GameObject Obj_A; // 유니티 Scene에 생성된 오브젝트의 정보를 가져오기 위한 변수
    [SerializeField]
    private GameObject Obj_B;
    [SerializeField]
    private GameObject Obj_C;

    private GameObject Test_Cube;
    public Mesh Test_Cube_Mesh;
    public Material Test_Cube_Material;
    
    private string Obj_Name = "Renamed";

    private void Start()
    {
        // GameObject_Tutorial();
        CreateCube("Hello World");
    }

    private void GameObject_Tutorial() // 유니티 Scene에 있는 오브젝트를 코드로 접근하는 함수
    {
        // 유니티 Scene에 생성된 오브젝트 중 "Player" 태그를 가진 오브젝트를 찾아 변수 Obj_B에 대입하는 코드
        Obj_B = GameObject.FindGameObjectWithTag("Player");
        Obj_B.name = Obj_Name;
        
        // 유니티 Scene에 생성된 모든 오브젝트를 읽고 이름 "Cube" 를 찾아 변수 Obj_B에 대입하는 코드
        // 같은 이름을 가진 오브젝트가 있을경우 가장 아래에 있는 오브젝트를 가져오기 때문에 의도되지 않은 상황이 발생가능
        Obj_C = GameObject.Find("Cube"); 
        
        Obj_C.name = Obj_Name;
        Obj_A.name = Obj_Name;
        
        // 오브젝트에 있는 Component에 접근하기 위해 GetComponent<ComponentName>()를 사용하여 접근함
        Debug.Log($"Material 데이터 : {Obj_B.GetComponent<MeshRenderer>().material.name}");
        // Obj_B에 있는 MeshRenderer Component에 접근하여 Component 비활성화
        Obj_B.GetComponent<MeshRenderer>().enabled = false;
        Obj_B.GetComponent<Transform>().position = new Vector3(1,0,3);
        // 오브젝트에는 반드시 transform Component를 가지기 때문에 GetComponent를 사용하지 않아도 접근 가능
        Obj_C.transform.position = new Vector3(1,0,2);
        
        if ( Obj_C.transform.gameObject == Obj_C)
        {
            Debug.Log("Obj_C.transform.gameObject 는 Obj_C 와 같다");
        }
        
        // 오브젝트의 활성상태를 비활성화
        Obj_C.SetActive(false);
    }

    private void CreateCube(string _name = "Cube") // Cube 오브젝트를 코드로 만들기 위한 함수
    {
        // Test_Cube = new GameObject();
        // Test_Cube.name = "Cube"
        Test_Cube = new GameObject(_name);

        Test_Cube.AddComponent<MeshFilter>();
        Test_Cube.GetComponent<MeshFilter>().mesh = Test_Cube_Mesh;
        
        Test_Cube.AddComponent<MeshRenderer>();
        Test_Cube.GetComponent<MeshRenderer>().material = Test_Cube_Material;
        
        Test_Cube.AddComponent<BoxCollider>();
    }
}


