using System;
using UnityEngine;

public abstract class Knight_MonsterCore : MonoBehaviour
{
    public enum MonsterState {IDLE , PATROL, TRACE, ATTACK}
    public MonsterState monsterstate = MonsterState.IDLE;

    
    protected Animator monster_Ani;
    protected Rigidbody2D monster_Rb;
    protected Collider2D monster_Coll;
    
    public Transform target;
    
    public float hp;
    public float speed;
    protected float moveDir;
    protected float targetDist;
    protected float attackTime;

    protected bool isTrace;
    
    protected virtual void Init(float hp, float speed, float attackTime) 
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        this.hp = hp;
        this.speed = speed;
        this.attackTime = attackTime;
        
        monster_Ani = GetComponent<Animator>();
    }

    private void Update()
    {
        targetDist = Vector3.Distance(transform.position, target.position);
        
        Vector3 monsterDir = Vector3.right * moveDir;
        Vector3 playDir = (transform.position - target.position).normalized;

        float dotValue = Vector3.Dot(monsterDir, playDir);

        isTrace = dotValue < -0.5f && dotValue >= -1f; // 서로 마주보고 있으면 -1, 뒤돌고 있으면 1
        
        switch (monsterstate)
        {
            case MonsterState.IDLE: // 대기 상태
                Idle();
                break;
            case MonsterState.PATROL: // 정찰 상태
                Patrol();
                break;
            case MonsterState.TRACE: // 추적 상태
                Trace();
                break;
            case MonsterState.ATTACK: // 공격 상태
                Attack();
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Return"))
        {
            moveDir *= -1;
            transform.localScale = new Vector3(moveDir, 1f, 1f);
        }
    }

    public abstract void Idle();
    public abstract void Patrol();
    public abstract void Trace();
    public abstract void Attack();

    public void ChangeState(MonsterState newstate) // 디버깅, 유지보수에 유리함
    {
        if (monsterstate != newstate)
        {
            monsterstate = newstate;
        }
    }
}
