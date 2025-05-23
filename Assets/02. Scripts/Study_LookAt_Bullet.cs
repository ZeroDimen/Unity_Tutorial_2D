using UnityEngine;

public class Study_LookAt_Bullet : MonoBehaviour 
{
    // 생성할 Bullet 프리펩을 이동시키는 스크립트
    public float Bullet_Speed =10f;
    void Update()
    {
        // 월드 상의 정면으로 발사하는 코드
        //this.gameObject.transform.position += Vector3.forward * (Bullet_Speed * Time.deltaTime); 
        
        // 로컬 상의 정면으로 발사하는 코드
        this.gameObject.transform.position += this.gameObject.transform.forward * (Bullet_Speed * Time.deltaTime); 
    }
}
