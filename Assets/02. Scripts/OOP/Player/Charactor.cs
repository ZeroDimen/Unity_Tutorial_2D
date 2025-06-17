using System;
using UnityEngine;

// Student와 Soldier의 공통된 변수 및 함수를 줄이기 위한 부모 클래스
public abstract class Charactor : MonoBehaviour
{
    public IDropItem curruntItem ;
    [SerializeField] private Transform GrabpPos;
    
    public float hp;
    public float moveSpeed;

    private void Update()
    {
        Interaction();
    }

    private void Interaction()
    {
        if (curruntItem == null)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (curruntItem != null)
            {
                curruntItem.Use();
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            if (curruntItem != null)
            {
                curruntItem.Drop();
                curruntItem = null;
            }
        }
    }

    public void Move()
    {
        Debug.Log("이동");
    }

    public virtual void Attack() 
    {
        // virtual : 기본 기능 구현, 필요하면 자식 클래스에서 수정가능
        // 편리함, 실수 방지 불가, base 활용 가능
        Debug.Log("공격");
    }

    public abstract void Hit(); 
    //  abstract : 확실하게 재정의가 필요한 경우 ( 기능 구현을 자식 클래스에게 넘김)
    // 불편함, 실수 방지 가능 base 활용 불가

    private void OnTriggerEnter(Collider other)
    {
        // 감지된 대상이 IDropItem이 있다면 , 아이템 2가지 이상 소지 불가
        if (other.GetComponent<IDropItem>() != null && curruntItem == null)
        {
            IDropItem item = other.GetComponent<IDropItem>();
            item.Grab(GrabpPos); // 아이템 획득
            curruntItem = item; // 현제 아이템 장착
        }
    }
}