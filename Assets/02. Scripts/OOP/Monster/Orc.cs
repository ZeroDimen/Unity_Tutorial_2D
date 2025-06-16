// Study_Casting 스크립트에서 형변환을 위해 사용됨

using UnityEngine;

public class Orc : Monster, IMove
{
    public float hp;
    public float moveSpeed;

    public void Move()
    {
        Debug.Log("Move");
    }

    public void Attack()
    {
        Debug.Log("Attack");
    }

    public override void SetHealth()
    {
        hp = 50f;
    }
}
