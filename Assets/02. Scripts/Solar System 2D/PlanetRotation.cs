using UnityEngine;

// 행성 오브젝트의 공전 및 자전을 관리하는 스크립트
public class PlanetRotation : MonoBehaviour
{
    public Transform Target_Planet;
    public float Rot_Speed = 30f; // 자전 속도
    public float Rev_Speed = 100f; // 공전 속도

    public bool is_Rev = false; // 공전 유무
    private void Update()
    {
        // 자기 자신을 로컬 축 기준으로 회전하는 기능
        this.gameObject.transform.Rotate(this.gameObject.transform.up * (Rot_Speed * Time.deltaTime));
        
        if (is_Rev == true)
        {
            // RotateAround(Vector3 공전 대상, Vector3 회전축, float 속도) 공전하는 기능
            this.gameObject.transform.RotateAround(Target_Planet.position, Vector3.up, Rev_Speed * Time.deltaTime);
        }
    }
}
