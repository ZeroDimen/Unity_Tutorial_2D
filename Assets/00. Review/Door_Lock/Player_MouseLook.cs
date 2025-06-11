using UnityEngine;

public class Player_MouseLook : MonoBehaviour
{
   
    public float mouseSensitivity = 500f;    // 마우스 민감도
    
    public Transform playerBody;
    
    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 마우스 커서 안보이게하는 함수
    }

    void Update()
    {
        // 마우스의 X, Y 축 값
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        xRotation -= mouseY;
        
        // 카메라 뒤집히는것 방지 (상하 회전 각 -90도~90도 사이로 제한)
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // 계산된 상하 회전 값을 카메라(스크립트가 붙은 오브젝트)의 X축 회전에 적용
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        //카메라가 캐릭터를 따라 좌우로 같이 회전
        playerBody.Rotate(Vector3.up * mouseX);
    }
}