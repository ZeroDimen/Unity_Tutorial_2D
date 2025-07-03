using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Goblin : Knight_MonsterCore, IDamageable
{
    
    private float timer;
    private float patrolTime , idleTime;
    private float traceDist = 4f;
    private float attackDist = 2f;
    private bool isAttack;
    
    private void Start()
    {
        Init(10f, 2f , 0.7f, 3f);
    }

    protected override void Init(float maxHp, float speed, float attackTime, float attackDamage)
    {
        base.Init(maxHp, speed, attackTime, attackDamage);
        StartCoroutine(FindPlayerRoutine());
    }

    IEnumerator FindPlayerRoutine()
    {
        while (true)
        {
            yield return null;
            targetDist = Vector3.Distance(transform.position, target.position);

            if (monsterstate == MonsterState.IDLE || monsterstate == MonsterState.PATROL)
            {
                Vector3 monsterDir = Vector3.right * moveDir;
                Vector3 playerDir = (transform.position - target.position).normalized;
            
                float dotValue = Vector3.Dot(monsterDir, playerDir);
            
                isTrace = dotValue < -0.5f && dotValue >= -1f; // 서로 마주보고 있으면 -1, 뒤돌고 있으면 1
                
                if (targetDist  <= traceDist && isTrace)
                {
                    timer = 0f;
                    monster_Ani.SetBool("isRun", true);
                    ChangeState(MonsterState.TRACE);
                }
            }
            else if (monsterstate == MonsterState.TRACE)
            {
                if (targetDist > traceDist)
                {
                    timer = 0f;
                    idleTime =Random.Range(1f, 3f);
                    
                    monster_Ani.SetBool("isRun", false);
                    ChangeState(MonsterState.IDLE);
                }
        
                if (targetDist < attackDist)
                {
                    ChangeState(MonsterState.ATTACK);
                }
            }
        }
        
        
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
        hpBar.transform.localScale = new Vector3(scaleX, 1, 1);
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
        monster_Ani.SetTrigger("Attack");
        float currAniLength = monster_Ani.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(currAniLength);
        
        monster_Ani.SetBool("isRun", false);
        var targetDir = (target.position - transform.position).normalized;
        var scaleX = targetDir.x > 0 ? 1 : -1;
        transform.localScale = new Vector3(scaleX, 1, 1);
        hpBar.transform.localScale = new Vector3(scaleX, 1, 1);
        yield return new WaitForSeconds(attackTime);
        
        isAttack = false;
        monster_Ani.SetBool("isRun", true);
        ChangeState(MonsterState.TRACE);
    }
}
