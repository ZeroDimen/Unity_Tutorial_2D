using UnityEngine;

// Animator를 사용한 문 오브젝트 회전
public class Door_Event : MonoBehaviour
{
    private Animator Door_ani;

    private void Start()
    {
        Door_ani = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Door_ani.SetTrigger("IsTrigger");
        }
    }
}
