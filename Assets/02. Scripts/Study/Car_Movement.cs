using UnityEngine;

// Rigidbody를 통한 Car 오브젝트 이동 제어 (충돌 감지)
public class Car_Movement : MonoBehaviour
{
    public float Car_Speed = 5f;
    private Rigidbody2D Car_Rb;
    private float h;

    private void Start()
    {
        Car_Rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update() // 성능에 따라 다른 프레임으로 실행되는 유니티 기본 함수, 키 입력
    {
        h = Input.GetAxis("Horizontal"); // 키보드 A(-1), D(1) 버튼을 통해 이동

        // Transform을 사용한 이동, 좌표를 사용한 순간이동 따라서 충돌시 떨림 문제 생김
        // this.gameObject.transform.position += Vector3.right * (h * Car_Speed * Time.deltaTime);
        // this.gameObject.transform.Translate(Vector3.right * (h * Car_Speed * Time.deltaTime));


    }

    private void FixedUpdate() // 고정 프레임으로 실행되는 유니티 기본 함수, 물리적인 작용,Time.deltaTime 사용 안해도됨
    {
        // Rigidbody를 사용한 이동 // 물리적인 이동으로 충돌시 떨림 문제 해결
        Car_Rb.linearVelocityX = Car_Speed * h;
    }

    private void OnCollisionEnter2D(Collision2D collision) // 충돌했을 경우 1번 호출 
    {
        Debug.Log("collision Enter");
    }

    private void OnCollisionStay2D(Collision2D collision) // 충돌중일 경우 계속 호출 
    {
        Debug.Log("collision Stay");
    }

    private void OnCollisionExit2D(Collision2D collision) // 충돌이 끝났을 경우 1번 호출 
    {
        Debug.Log("collision Exit");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("OnTriggerStay");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("OnTriggerExit");
    }
}
