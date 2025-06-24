using UnityEngine;
using UnityEngine.UI;

public class KnightController_Joystick : MonoBehaviour
{

    private Animator knightAni;
    private Rigidbody2D knightRb;

    [SerializeField] private Button jumpButton;
    [SerializeField] private Button attackButton;
    
    private Vector3 inputDir;
    [SerializeField]
    private float moveSpeed = 3f;
    [SerializeField]
    private float jumpPower = 12f;

    private bool isGround = false;
    private bool isCombo = false;
    private bool isAttack = false;
    
    private void Start()
    {
        knightAni = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();
        
        jumpButton.onClick.AddListener(Jump);
        attackButton.onClick.AddListener(Attack);
    }

    private void Update() // 일반적인 작업
    {
        
    }

    private void FixedUpdate() // 물리적인 작업
    {
        Move();
    }
    
    private void Jump()
    {
        if (isGround)
        {
            knightAni.SetTrigger("jump");
            knightRb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }

    public void InputJoystick(float x, float y)
    {
        inputDir = new Vector3(x, y, 0).normalized;
        
        knightAni.SetFloat("joystickX", x);
        knightAni.SetFloat("joystickY", y);

        if (inputDir.x != 0)
        {
            var scaleX = inputDir.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX,1,1);
        }
    }

    private void Move()
    {
        if (inputDir.x != 0)
        {
            knightRb.linearVelocityX = inputDir.x * moveSpeed; // transfrom을 사용한 이동은 벽을 관통할 가능성이 있음
        }
    }

    private void Attack()
    {
        if (isAttack)
        {
            isCombo = true;
        }
        else
        {
            isAttack = true;
            knightAni.SetTrigger("attack");
        }
        
    }

    private void CheckCombo()
    {
        if (isCombo)
        {
            knightAni.SetBool("isCombo", true);
        }
        else
        {
            knightAni.SetBool("isCombo", false);
            isAttack = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            knightAni.SetBool("isGround",true);
            isGround = true;
            
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            knightAni.SetBool("isGround", false);
            isGround = false;
        }
    }
}
