using UnityEngine;
using Cat; // 사운드 메니저가 있는 namespace

// 고양이 오브젝트를 이동 및 2단 점프 구현 코드
public class Cat_Controller : MonoBehaviour
{
    public Cat_SoundManager soundManager; // public으로 설정 했기 때문에 유니티 상에서 할당 예정

    private Rigidbody2D Cat_Rb;
    private Animator Cat_Anim;
    public float Cat_Speed;
    public float Cat_JumpForce;
    private float h;
    public int Cat_Jumpcount; // 현재 점프 수

    private bool IsGround;

    void Start()
    {
        Cat_Rb = gameObject.GetComponent<Rigidbody2D>();
        Cat_Anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && Cat_Jumpcount < 2) // 스페이스 키 입력하면 실행, 연속 점프 기능
        {
            // AddForceY(Float 속도, Mode)
            Cat_Rb.AddForceY(Cat_JumpForce, ForceMode2D.Impulse);
            Cat_Jumpcount++;
            Cat_Anim.SetBool("IsGround", false); // 점프 에니메이션 출력
            soundManager.OnJumpSound();
        }

        // 점프시 고양이의 Rotion 변경
        var catRotion = transform.eulerAngles;
        catRotion.z = Cat_Rb.linearVelocityY * 2.5f;
        transform.eulerAngles = catRotion;
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
            Cat_Anim.SetBool("IsGround", true); // 걷기 에니메이션 출력

        }

    }
}
