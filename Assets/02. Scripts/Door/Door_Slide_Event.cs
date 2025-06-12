using UnityEngine;

// Animator를 사용한 문 오브젝트 슬라이드 이동 구현
public class Door_Slide_Event : MonoBehaviour
{
    private Animator anim;
    public GameObject KeyPad;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            KeyPad.SetActive(true);
            // anim.SetTrigger("IsFront");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            KeyPad.SetActive(false);
            // anim.SetTrigger("IsClose");
        }
    }
}
