using System;
using UnityEngine;
using Cat; // 사운드 메니저가 있는 namespace

// 고양이 오브젝트를 이동 및 2단 점프 구현 코드
public class Cat_Controller : MonoBehaviour
{
    public Cat_SoundManager soundManager; // public으로 설정 했기 때문에 유니티 상에서 할당 예정
    public Cat_UIManager uiManager;
    
    private Rigidbody2D Cat_Rb;
    private Animator Cat_Anim;
    public float Cat_Speed;
    public float Cat_JumpForce;
    public float Cat_SpinPower;
    
    private float h;
    public int Cat_Jumpcount; // 현재 점프 수
    public static bool isEnding; // 게임 앤딩시 입력을 받지 못하게 하기위한 변수

    private void Awake() // 한번만 실행, OnEnable 보다 일찍 실행되야하므로 Start() -> Awake() 변경
    {
        Cat_Rb = gameObject.GetComponent<Rigidbody2D>();
        Cat_Anim = gameObject.GetComponent<Animator>();
    }

    private void OnEnable() // 오브젝트 활성화 마다 한번씩 실행
    {
        transform.localPosition = new Vector3(-6, 0, 0); // 고양이 처음 위치 지정
        transform.rotation = Quaternion.Euler(0, 0, 0); // 회전 초기화
        GetComponent<CircleCollider2D>().enabled = true;
        isEnding = false;
    }

    private void Update()
    {
        if (!isEnding)
        {
            Jump();
        }
        else
        {
            transform.Rotate(0,0,  - Cat_SpinPower);
        }
        
    }
    private void FixedUpdate()
    {
        if (!isEnding)
        {
            Move();
        }
    }

    private void Jump()
    {
        h = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && Cat_Jumpcount < 2) // 스페이스 키 입력하면 실행, 연속 점프 기능
        {
            // AddForceY(Float 속도, Mode)
            Cat_Rb.AddForceY(Cat_JumpForce, ForceMode2D.Impulse);
            Cat_Jumpcount++;
            soundManager.OnJumpSound();
            Cat_Anim.SetBool("IsGround", false); // 점프 에니메이션 출력 , 자연스러운 낙하는 아님 개선 필요
        }

        // 점프시 고양이의 Rotion 변경
        var catRotion = transform.eulerAngles;
        catRotion.z = Cat_Rb.linearVelocityY * 2.5f;
        transform.eulerAngles = catRotion;
        
    }

    private void Move()
    {
        Cat_Rb.linearVelocityX = h * Cat_Speed;
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Cat_Jumpcount = 0;
        if (collision.gameObject.CompareTag("Ground")) // 바닥 충돌시
        {
            Cat_Anim.SetBool("IsGround", true); // 걷기 에니메이션 출력
        }
        else if (collision.gameObject.CompareTag("Pipe"))  // 파이프 충돌시
        {
            Cat_Rb.AddForceY(Cat_JumpForce, ForceMode2D.Impulse);
            soundManager.Oncollider();
            uiManager.Ending(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fruit")) // 과일과 닿았을 경우
        {
            other.gameObject.SetActive(false);
            // Fruit의 부모 오브젝트 컴포넌트에서 particle 오브젝트를 가져와서 활성화
            other.transform.parent.GetComponent<Cat_ItemEvent>().particle.SetActive(true); // 사라진 효과 출력
            Cat_GameManager.Score ++;
            soundManager.Oncollider();

            if (Cat_GameManager.Score == 5)
            {
                uiManager.Ending(true);
            }
        }
    }
}
