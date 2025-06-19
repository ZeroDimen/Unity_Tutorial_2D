using System.Collections;
using UnityEngine;

// 캐릭터 오브젝트를 이동하기 위한 스크립트
public class Character_Movement : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private GameObject hitBox;
    [SerializeField] private float moveSpeed;
    private float h, v;

    private bool IsAttack = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Attack();
    }

    void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (h == 0 && v == 0) // 움직이지않는 상태 -> Idle animation
        {
            animator.SetBool("IsRun", false);
        }
        else // 움직이는 상태 -> Run animation
        {
            if (h > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (h < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            animator.SetBool("IsRun", true);
        }
        
        var dir = new Vector3(h, v, 0).normalized;
        transform.position += dir * (moveSpeed * Time.deltaTime);
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsAttack == false)
        {
            StartCoroutine(HitBox());
        }
    }

    IEnumerator HitBox()
    {
        IsAttack = true;
        hitBox.SetActive(true);
        
        yield return new WaitForSeconds(0.25f);
        hitBox.SetActive(false);
        
        yield return new WaitForSeconds(0.75f);
        IsAttack = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Monster>() != null) // Monster컴포넌트가 있다면
        {
            Monster monster = other.GetComponent<Monster>();
            StartCoroutine(monster.Hit(1));
        }
    }

    void OnCollisionEnter2D(Collision2D other) // 바로 GetComponent를 사용할수 없음
    {
        if (other.gameObject.GetComponent<IItem>() != null) // Monster컴포넌트가 있다면
        {
            IItem item = other.gameObject.GetComponent<IItem>();
            item.Get();
        }
    }
}
