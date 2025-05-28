using UnityEngine;

// 오브젝트를 방향키 입력을 통해 이동 및 회전하는 스크립트
// 땅에 닿는 z회전 값에 따라 다른 로그 출력하는 기능
public class Review_Cat_Movement : MonoBehaviour
{
    private Rigidbody2D Cat_Rb;
    private float h;
    private bool IsGround;
    private int Cat_J_Count;
    
    public Transform Cat_Trans;
    
    public float Cat_Safe_Rotation;
    public float Cat_Speed;
    public float Cat_J_force;
    public float Cat_S_force;
    
    
    private void Start()
    {
        Cat_Rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        h = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && Cat_J_Count < 2)
        {
            Cat_Rb.AddForceY(Cat_J_force, ForceMode2D.Impulse);
            Cat_J_Count++;
        }
        
    }

    private void FixedUpdate()
    {
        Cat_Rb.linearVelocityX = Cat_Speed * h;
        if (!IsGround)
        {
            Cat_Trans.Rotate(0,0,- h * Cat_S_force);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            // Cat_Trans.eulerAngles.z의 값은 0 ~ 360 사이의 값으로 출력
            // Cat_Trans.rotation.z의 값은 -1 ~ 1 사이의 값으로 출력
            // 조건문 가독성을 위해 Cat_Trans.rotation.z의 절댓값을 사용
            
            float Cat_Now_Rot = Mathf.Abs(Cat_Trans.rotation.z);
            
            if (Cat_Now_Rot <= Cat_Safe_Rotation) // 착지 시 회전 방향에 따른 로그 출력 
            {
                Debug.Log("Happy");
            }
            else if (Cat_Now_Rot >= 0.7f)
            {
                Debug.Log("Bad");
            }
            else
            {
                Debug.Log("Sad");
            }
            
            IsGround = true;
            Cat_J_Count = 0;
            Cat_Trans.rotation = Quaternion.Euler(0, 0, 0); // 회전 초기화
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsGround = false;
        }
    }
}
