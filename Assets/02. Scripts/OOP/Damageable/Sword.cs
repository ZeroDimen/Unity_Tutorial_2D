using UnityEngine;

// IDamageable인터페이스를 가진 Door는 데미지 주기 가능, 없는 Wall은 데미지 주기 불가능
public class Sword : MonoBehaviour
{ 
        void OnTriggerEnter(Collider other)
        {
                // 감지된 대상에게 IDamageable가 있다면
                if (other.GetComponent<IDamageable>() != null)
                {
                        // 그 대상에게 데미지 10을 준다.
                        other.GetComponent<IDamageable>().TakeDamage(10f);
                }
        }
}