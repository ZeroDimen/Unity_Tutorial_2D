using UnityEngine;

// 마우스 입력을 통해 플레이어와 카메라를 회전 시키는 스크립트
public class Player_MouseLook : MonoBehaviour
{
   
    public float mouseSensitivity;    // 마우스 민감도
    public Transform playerCamera;
    
    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 마우스 커서 안보이게하는 함수
    }

    void Update()
    {
        // 마우스 회전을 입력 받기위한 변수 X, Y 
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        xRotation -= mouseY;
        
        // 카메라 뒤집히는것 방지 (상하 회전 각 -90도 ~ 90도 사이로 제한)
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // 마우스 회전에 따라 카메라 회전
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        // 마우스 회전에 따라 캐릭터 오브젝트 회전
        transform.Rotate(Vector3.up * mouseX);
    }
}