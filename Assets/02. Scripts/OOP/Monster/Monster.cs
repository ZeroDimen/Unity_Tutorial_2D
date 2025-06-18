using System.Collections;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{ 
    private SpriteRenderer sRenderer;
    private Animator animator;
    
    private SpawnerManager spawnerManager;
    protected float hp = 3f;
    protected float moveSpeed = 3f;

    private bool isMove;
    private bool isHit; // 반복 클릭 방지

    public int dir = 1;
    public abstract void Init();

    private void Start()
    {
        spawnerManager = FindFirstObjectByType<SpawnerManager>(); // SpawnerManager타입을 가진 오브젝트를 할당하는 함수
        
        sRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        isMove = true;
        isHit = false;
        
        Init();
    }

    protected void OnMouseDown()
    {
        // Hit(1); // 일반적인 함수 호출
        StartCoroutine(Hit(1)); // 코루틴 함수 호출
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        if (isMove)
        {
            transform.position += Vector3.right * (dir * moveSpeed * Time.deltaTime);
        
            if (transform.position.x > 8f)
            {
                sRenderer.flipX = true;
                dir = -1;
            }
            else if (transform.position.x < -8f)
            {
                sRenderer.flipX = false;
                dir = 1;
            }
        }
        
    }

    IEnumerator Hit(float damage) // IEnumerator는 yield가 반드시 필요
    {
        if (!isHit)
        {
            isHit = true;
            isMove = false;
            animator.SetTrigger("Hit");
            hp -= damage;
            if (hp <= 0)
            {
                animator.SetTrigger("Death");

                spawnerManager.DropItem(transform.position);
                
                yield return new WaitForSeconds(2f);
                
                Destroy(gameObject); // 비용이 높으므로 오브젝트를 끄는 방법 추천
                // gameObject.SetActive(false);
                
                Debug.Log("Monster Dead");
                yield break;
            }
            yield return new WaitForSeconds(0.7f);
            isMove = true;
            isHit = false;
        }
        
        
    }
}
