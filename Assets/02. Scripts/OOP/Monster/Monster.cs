using System;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{ 
    private SpriteRenderer sRenderer;
    protected float hp = 3f;
    protected float moveSpeed = 3f;

    public int dir = 1;
    public abstract void Init();

    private void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        Init();
    }

    private void OnMouseDown()
    {
        Hit(1);
    }

    private void Update()
    {
        Move();
    }

    void Move()
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

    void Hit(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Debug.Log("Monster Dead");
            Destroy(this.gameObject);
        }
    }
}
