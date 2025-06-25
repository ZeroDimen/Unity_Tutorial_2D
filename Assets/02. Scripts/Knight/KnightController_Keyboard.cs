using System;
using UnityEngine;

public class KnightController_Keyboard : MonoBehaviour
{

    private Animator knightAni;
    private Rigidbody2D knightRb;

    private Vector3 inputDir;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpPower = 12f;

    private bool isGround = false;
    private bool isCombo = false;
    private bool isAttack = false;

    private void Start()
    {
        knightAni = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();
    }

    private void Update() // 일반적인 작업
    {
        InputKeyboard();
        Jump();
        Attack();
    }

    private void FixedUpdate() // 물리적인 작업
    {
        Move();
    }

    private void InputKeyboard()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        inputDir = new Vector3(h, v, 0);

        knightAni.SetFloat("inputDirX", inputDir.x);
        knightAni.SetFloat("inputDirY", inputDir.y);
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && isGround)
        {
            knightAni.SetTrigger("jump");
            {
                knightRb.AddForceY(jumpPower, ForceMode2D.Impulse);
            }
        }
    }

    private void Move()
    {
        if (inputDir.x != 0)
        {
            var scaleX = inputDir.x > 0 ? 1 : -1; // 플립기능
            transform.localScale = new Vector3(scaleX, 1, 1);

            knightRb.linearVelocityX = inputDir.x * moveSpeed; // transfrom을 사용한 이동은 벽을 관통할 가능성이 있음
        }
    }
    
    
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.P))
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

    public void EndCombo()
    {
        isCombo = false;
        isAttack = false;
        knightAni.SetBool("isCombo", false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            knightAni.SetBool("isGround", true);
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
