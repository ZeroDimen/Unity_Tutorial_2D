using UnityEngine;

// 코드로 점을 찍어 mesh를 사용해 필터와 렌더링을 하여 면을 생성하는 스크립트
public class Study_Polygon : MonoBehaviour
{
    private void Start()
    {
        Mesh mesh = new Mesh(); // 형태 데이터가 들어갈 Mesh 타입의 변수 생성

        Vector3[] vertices = new Vector3[] // 점 4개 찍기
        {
            new Vector3 (0,0,0), 
            new Vector3 (1,0,0), 
            new Vector3 (0,1,0), 
            new Vector3 (1,1,0)
        };

        int[] triagles = new int[] // 삼각형 순서
        {
            0, 2, 1,
            2, 3, 1
        };

        Vector2[] uv = new Vector2[] // 면의 방향
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };
        
        // Mesh에 위에서 만든 점, 삼각형 순서, uv 데이터를 적용
        mesh.vertices = vertices;
        mesh.triangles = triagles;
        mesh.uv = uv;
        
        // MeshFilter에 Mesh 데이터를 적용
        MeshFilter meshFilter = this.gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;
        
        // MeshRenderer에 Material 데이터를 적용
        MeshRenderer meshRenderer = this.gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Sprites/Default"));
    }

}
