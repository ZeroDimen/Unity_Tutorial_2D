using UnityEngine;

// 콜라이더를 사용하여 충돌 판정을 확인하는 함수
public class ColliderEvent : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) // 상호작용을 하는 둘 다 콜라이더에 isTrigger를 비활성화일 경우 호출
    {
        Debug.Log("OnCollisionEnter");
    }

    private void OnTriggerEnter(Collider other) // 상호작용을 하는 둘 중 하나라도 콜라이더에 isTrigger를 활성화일 경우 호출
    {
        Debug.Log("OnTriggerEnter");
    }
}
