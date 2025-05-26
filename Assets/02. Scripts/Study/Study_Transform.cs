using UnityEngine;

// 오브젝트를 로컬, 월드 좌표계에서 이동 및 회전하는 스크립트
public class Study_Transform : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float RotateSpeed = 70f;

    private void Update()
    {
        // 로컬 방향으로 이동
        // transform.localPosition += Vector3.forward * (MoveSpeed * Time.deltaTime);
        // transform.Translate(Vector3.forward * (MoveSpeed * Time.deltaTime), Space.Self); // Space.Self 생략가능
        
        // 월드 방향으로 이동
        // transform.position += Vector3.forward * (MoveSpeed * Time.deltaTime);
        // transform.Translate(Vector3.forward * (MoveSpeed * Time.deltaTime), Space.World);
        
        // Quaternion(사원수).Euler(오일러값)(float x, float y, float z);
        
        // 로컬 방향으로 회전
        // transform.Rotate(Vector3.up, RotateSpeed *Time.deltaTime, Space.Self); // Space.Self 생략가능
        
        // 월드 방향으로 회전 
        // transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + RotateSpeed * Time.deltaTime, 0);
        //transform.Rotate(Vector3.up, RotateSpeed * Time.deltaTime, Space.World);
        
        
        // 특정 위치의 주변을 회전
        // transform.RotateAround(Vector3 point, Vector3 axis, float angle)
        // transform.RotateAround(new Vector3(0f, 0f, 0f), new Vector3(0f, 1f, 0f), RotateSpeed * Time.deltaTime);
        transform.RotateAround(Vector3.zero, Vector3.up, RotateSpeed * Time.deltaTime);
        
        // 특정 위치를 바라보며 회전
        transform.LookAt(Vector3.zero);
    }
}
