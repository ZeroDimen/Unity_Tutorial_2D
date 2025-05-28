using UnityEngine;

// 오브젝트에 충돌했을 경우 로그를 띄우는 스크립트
public class Cat_Pipe : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over");
        }
    }
}
