using UnityEngine;

public class Platform_Push : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D targetRb;
    
    [SerializeField]
    private float jumpPower;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            targetRb = other.GetComponent<Rigidbody2D>();
            Invoke("PushPlayer", 1f);
        }
    }

    private void PushPlayer()
    {
        targetRb.AddForceY(jumpPower, ForceMode2D.Impulse);
        anim.SetTrigger("push");
    }
}
