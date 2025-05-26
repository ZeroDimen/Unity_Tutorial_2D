using UnityEngine;

// 룰렛 오브젝트를 회전하기 위한 스크립트
public class Roulette_Controller : MonoBehaviour
{
    [SerializeField] private float RotSpeed;
    [SerializeField] private bool IsStop = false;
    private void Update()
    {
        // Vector3.forward = Vector3(0f, 0f, 1f);
        // this.gameObject.transform.Rotate(Vector3.forward * (RotSpeed * Time.deltaTime)); 같음
        this.gameObject.transform.Rotate(0f, 0f, RotSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0) && IsStop == false) // 마우스 왼쪽 버튼을 눌렀을 때 회전
        {
            RotSpeed = 500f;
        }

        if (Input.GetKeyDown(KeyCode.Space)) // 키보드 스페이스 버튼을 눌렀을 때 멈춤
        {
            IsStop = true;
        }

        if (IsStop == true)
        {
            RotSpeed *= 0.9f; // 현재 속도에서 특정 값만큼 줄이는 기능
            if (RotSpeed < 0.1f)
            {
                RotSpeed = 0f;
                IsStop = false;
            }
        }
        

    }
}
