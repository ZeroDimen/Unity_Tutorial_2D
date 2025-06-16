using UnityEngine;

// 오버로딩을 확인하는 스크립트
// Player 기능 구현
public class Study_Overloading : MonoBehaviour
{
    private void Start()
    {
        Attack(false);
        Attack(true);
        Attack(15);
        Attack(10, new GameObject("Orc"));
    }
    public void Attack(bool isMagic)
    {
        if (isMagic)
        {
            Debug.Log("Magic Attack");
        }
        else
        {
            Debug.Log("Attack");
        }
    }

    public void Attack(float damage)
    {
        Debug.Log($"AD : {damage}");
    }

    public void Attack(float damage, GameObject target)
    {
        Debug.Log($"AD : {damage} to {target}");
    }
    
}
