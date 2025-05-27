using UnityEngine;

// Material을 움직여 반복되는 이미지를 만들기 위한 스크립트
public class Material_LoopMap : MonoBehaviour
{
    private MeshRenderer renderer; // Null
    public float offsetSpeed = 0.1f;

    private void Start()
    {
        renderer = this.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        Vector2 offset = Vector2.right * (offsetSpeed * Time.deltaTime); // 택스쳐가 이동할 위치를 저장하는 변수 
        // transform.position += offset 랑 같음
        // material을 이동하기 때문에 오차가 생기지않음
        renderer.material.SetTextureOffset("_MainTex", renderer.material.mainTextureOffset + offset);
    }
}
