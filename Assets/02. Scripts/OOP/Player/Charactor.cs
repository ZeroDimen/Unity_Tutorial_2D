using System;
using UnityEngine;

// Student와 Soldier의 공통된 변수 및 함수를 줄이기 위한 부모 클래스
public abstract class Charactor : MonoBehaviour
{
    public IDropItem curruntItem ;
    
    public float hp;
    public float moveSpeed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (curruntItem != null)
            {
                curruntItem.Use();
            }
            else
            {
                Debug.Log("현재 아이템이 없습니다.");
            }
            
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (curruntItem != null)
            {
                curruntItem.Drop();
                curruntItem = null;
            }
            else
            {
                Debug.Log("현재 아이템이 없습니다.");
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
        // 감지된 대상이 IDropItem이 있다면
        if (other.GetComponent<IDropItem>() != null)
        {
            IDropItem item = other.GetComponent<IDropItem>();
            item.Grab(); // 아이템 획득
            curruntItem = item; // 현제 아이템 장착
        }
    }
}