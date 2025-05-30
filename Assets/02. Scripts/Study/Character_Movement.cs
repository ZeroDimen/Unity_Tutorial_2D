using UnityEngine;

// 캐릭터 오브젝트를 이동하기 위한 스크립트
public class Character_Movement : MonoBehaviour
{
    private Rigidbody2D Character_Rb;
    public float Movement_Speed;
    public float Jump_Power;
    private bool isGrounded;
    private float h;
    public SpriteRenderer[] Character_Ani_SpriteRenderer;
    private void Start()
    {
        Character_Rb = this.gameObject.GetComponent<Rigidbody2D>();
        
        // 자식 오브젝트의 SpriteRenderer를 가지는 자식들을 가져옴, true 사용시 비활성화 된 오브젝트 또한 가져올 수 있음
        Character_Ani_SpriteRenderer = GetComponentsInChildren<SpriteRenderer>(true);
    }

    private void Update() // 키 입력
    {
        h = Input.GetAxis("Horizontal");
        Jump();
    }

    private void FixedUpdate() // 물리적 처리 연산
    {
        Move();
    }

    private void Move()
    {
        if (h != 0) // 움직일 때
        {
            if (isGrounded)
            {
                Character_Ani_SpriteRenderer[0].gameObject.SetActive(false); // Idle
                Character_Ani_SpriteRenderer[1].gameObject.SetActive(true); // Run
                Character_Ani_SpriteRenderer[2].gameObject.SetActive(false); // Jump
            }
            else
            {
                Character_Ani_SpriteRenderer[0].gameObject.SetActive(false); // Idle
                Character_Ani_SpriteRenderer[1].gameObject.SetActive(false); // Run
                Character_Ani_SpriteRenderer[2].gameObject.SetActive(true); // Jump
            }
            
            
            Character_Rb.linearVelocityX = h * Movement_Speed; // rigidbody 이동
            // 캐릭터의 움직임에 따라 이미지의 Flip 상태가 변하는 기능
            if (h < 0) // 왼쪽으로 갈때
            {
                Character_Ani_SpriteRenderer[0].flipX = true;
                Character_Ani_SpriteRenderer[1].flipX = true;
                Character_Ani_SpriteRenderer[2].flipX = true;
            }
            else if (h > 0) // 오른쪽으로 갈때
            {
                Character_Ani_SpriteRenderer[0].flipX = false;
                Character_Ani_SpriteRenderer[1].flipX = false;
                Character_Ani_SpriteRenderer[2].flipX = false;
            }
            
        }
        else // 움직이지 않을 때
        {
            Character_Ani_SpriteRenderer[0].gameObject.SetActive(true); // Idle
            Character_Ani_SpriteRenderer[1].gameObject.SetActive(false); // Run
            Character_Ani_SpriteRenderer[2].gameObject.SetActive(false); // Jump
        }
    }

    private void Jump() // 캐릭터가 +Y 방향으로 점프하는 기능
    {
        if (Input.GetButtonDown("Jump")) // Input.GetKeyDown(KeyCode.Space) 와 같음
        {
            Character_Rb.AddForce(Vector3.up*Jump_Power, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
