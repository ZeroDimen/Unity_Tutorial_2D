using UnityEngine;

// 코인 오브젝트 획득 및 제거
public class Door_Coin : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Movement.Coin_Count++; // 정적변수(static)을 사용하면 다른 스크립트에서도 쉽게 접근 가능
            Debug.Log($"Total Coin : {Movement.Coin_Count}");
            Destroy(this.gameObject);
        }
        
    }
}

