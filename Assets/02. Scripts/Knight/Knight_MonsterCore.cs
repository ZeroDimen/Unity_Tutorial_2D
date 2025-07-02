using UnityEngine;
using UnityEngine.UI;

public abstract class Knight_MonsterCore : MonoBehaviour
{
    public enum MonsterState {IDLE , PATROL, TRACE, ATTACK}
    public MonsterState monsterstate = MonsterState.IDLE;
    
    public Knight_ItemManager itemManager;
    
    [SerializeField] protected Image hpBar;
    
    protected Animator monster_Ani;
    protected Rigidbody2D monster_Rb;
    protected Collider2D monster_Coll;
    
    public Transform target;
    
    public float maxHp;
    public float currentHp;
    public float speed;
    protected float moveDir;
    protected float targetDist;
    protected float attackTime;
    public float attackDamage;

    protected bool isTrace;
    protected bool isDead;
    
    protected virtual void Init(float maxHp, float speed, float attackTime, float attackDamage) 
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        monster_Rb = GetComponent<Rigidbody2D>();
        monster_Coll = GetComponent<Collider2D>();
        
        itemManager =FindObjectOfType<Knight_ItemManager>();
        
        this.maxHp = maxHp;
        this.speed = speed;
        this.attackTime = attackTime;
        this.attackDamage = attackDamage;

        currentHp = maxHp;
        
        monster_Ani = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isDead)
        {
            return;
        }
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

        if (other.GetComponent<IDamageable>() != null)
        {
            Debug.Log("Att");
            other.GetComponent<IDamageable>().TakeDamage(attackDamage);
        }
    }

    public abstract void Idle();
    public abstract void Patrol();
    public abstract void Trace();
    public abstract void Attack();

    public void ChangeState(MonsterState newstate) // 디버깅, 유지보수에 유리함
    {
        monsterstate = newstate;
    }
}
