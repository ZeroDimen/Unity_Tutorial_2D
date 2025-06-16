using UnityEngine;

public class Car : MonoBehaviour , IMove// , Monster 다중상속 불가, 부모클래스는 하나만 상속
{
    public float moveSpeed;

    public void Move()
    {
        Debug.Log("Move");
    }
}