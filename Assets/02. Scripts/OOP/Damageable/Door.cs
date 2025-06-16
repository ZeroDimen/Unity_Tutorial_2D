using UnityEngine;

public class Door : MonoBehaviour , IDamageable
{
    public float hp;
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
        Debug.Log("문이 파괴되었습니다.");
    }
}