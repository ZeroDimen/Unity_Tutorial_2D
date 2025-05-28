using UnityEngine;

// 고양이 오브젝트를 이동 및 2단 점프 구현 코드
public class Cat_Controller : MonoBehaviour
{
    private Rigidbody2D Cat_Rb;
    public float Cat_Speed;
    public float Cat_JumpForce;
    private float h;
    public int Cat_Jumpcount; // 현재 점프 수
    
    private bool IsGround;
    void Start()
    {
        Cat_Rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        
        if (Input.GetKeyDown(KeyCode.Space) && Cat_Jumpcount < 2) // 스페이스 키 입력하면 실행, 연속 점프 기능
        {
            // AddForceY(Float 속도, Mode)
            Cat_Rb.AddForceY(Cat_JumpForce, ForceMode2D.Impulse);
            Cat_Jumpcount++;
        }
    }

    private void FixedUpdate()
    {
        Cat_Rb.linearVelocityX = h * Cat_Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Cat_Jumpcount = 0;

        }
        
    }
}
