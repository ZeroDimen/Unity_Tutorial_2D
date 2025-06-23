using System;
using UnityEngine;

public class KnightController_Joystick : MonoBehaviour
{

    private Animator knightAni;
    private Rigidbody2D knightRb;

    private Vector3 inputDir;
    [SerializeField]
    private float moveSpeed = 3f;
    [SerializeField]
    private float jumpPower = 12f;

    private bool isGround = false;
    
    private void Start()
    {
        knightAni = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();
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
            knightRb.linearVelocityX = inputDir.x * moveSpeed; // transfrom을 사용한 이동은 벽을 관통할 가능성이 있음
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            knightAni.SetBool("Ground",true);
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
