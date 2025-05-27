using UnityEngine;

// Material을 사용하여 오브젝트의 색상을 바꾸는 스크립트
public class Study_Material : MonoBehaviour 
{
    public Material mat;

    public string hexCode;  

    private void Start()
    {
        // this.GetComponent<Material>() = mat; Material을 바꾸는 형식 X
        // this.GetComponent<MeshRenderer>().material = mat; // MeshRenderer을 접근해서 바꾸는 형식 복사, Instance(복제)을 사용
        // this.GetComponent<MeshRenderer>().sharedMaterial = mat; // MeshRenderer을 접근해서 바꾸는 형식, 원본을 사용
        
        // this.GetComponent<MeshRenderer>().material.color = Color.black; // 오브젝트 material.color 값을 변경, Instance(복제)을 사용
        // this.GetComponent<MeshRenderer>().sharedMaterial.color = Color.red; // 원본 material.color 값을 변경, 원본을 사용
        
        Material mat = this.GetComponent<MeshRenderer>().material;
        
        Color outputColor;

        // ColorUtility.TryParseHtmlString("헥사코드", out 반환색상)
        if (ColorUtility.TryParseHtmlString(hexCode, out outputColor)) // 헥사코드를 사용한 색상값이 존재 할 경우
        {
            mat.color = outputColor;
        }
    }
    

    
   
}
