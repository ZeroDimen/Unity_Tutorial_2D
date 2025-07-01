using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Goblin : Knight_MonsterCore
{
    
    private float timer;
    private float patrolTime , idleTime;
    private float traceDist = 6f;
    private float attackDist = 2.5f;
    private bool isAttack;
    
    private void Start()
    {
        Init(10f, 2f , 1f);
    }

    protected override void Init(float hp, float speed, float attackTime)
    {
        base.Init(hp, speed, attackTime);
        // 추가기능
    }

    public override void Idle()
    {
        timer += Time.deltaTime;
        if (timer >= idleTime)
        {
            timer = 0f;
            moveDir = Random.Range(0, 2) == 0 ? -1 : 1;
            transform.localScale = new Vector3(moveDir, 1f, 1f);
            
            patrolTime = Random.Range(0f, 5f);
            
            monster_Ani.SetBool("isRun", true);
            ChangeState(MonsterState.PATROL);
        }

        if (targetDist  <= traceDist && isTrace)
        {
            timer = 0f;
            monster_Ani.SetBool("isRun", true);
            ChangeState(MonsterState.TRACE);
        }
        
    }

    public override void Patrol()
    {
        timer+= Time.deltaTime;
        transform.position += Vector3.right * (moveDir * speed * Time.deltaTime);
        
        idleTime = Random.Range(0f, 3f);
        
        if (timer >= patrolTime)
        {
            timer = 0f;
            monster_Ani.SetBool("isRun", false);
            ChangeState(MonsterState.IDLE);
        }
    }

    public override void Trace()
    {
        var tartgetDir = (target.position - transform.position ).normalized; // 방향만 구하는 백터
        transform.position += Vector3.right * (tartgetDir.x * speed * Time.deltaTime);

        var scaleX = tartgetDir.x > 0 ? 1 : -1;
       
        transform.localScale = new Vector3(scaleX, 1, 1);
        if (targetDist > traceDist)
        {
            monster_Ani.SetBool("isRun", false);
            ChangeState(MonsterState.IDLE);
        }
        
        if (targetDist < attackDist)
        {
            ChangeState(MonsterState.ATTACK);
        }
    }

    public override void Attack()
    {
        if (!isAttack)
        {
            StartCoroutine(AttackRoutine());
        }
    }

    IEnumerator AttackRoutine()
    {
        isAttack = true;
        monster_Ani.SetBool("isRun", false);
        monster_Ani.SetTrigger("Attack");
        yield return new WaitForSeconds(1f);
        
        
        yield return new WaitForSeconds(attackTime);
        isAttack = false;
        ChangeState(MonsterState.IDLE);
    }
    
}
