using UnityEngine;


public abstract class Monster :MonoBehaviour, IDamageable // 추상 클래스
{
    public float hp; 
    
    // 몬스터 마다 체력이 다르므로 필수로 재설정하는 함수가 필요함 따라서 abstract 사용
    public abstract void SetHealth(); // 추상함수 (직접적으로 사용불가능)
    public void TakeDamage(float damage)
    {
        Debug.Log($"{damage}만큼 피해를 입었습니다.");
        hp -= damage;
        if (hp <= 0)
        {
            Death();
        }
    }
    
    public void Death()
    {
        Debug.Log("몬스터 다운.");
    }
}
