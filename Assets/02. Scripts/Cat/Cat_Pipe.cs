using UnityEngine;

// 파이프 오브젝트에 충돌했을 경우 출력하는 스크립트
public class Cat_Pipe : MonoBehaviour
{
    public GameObject Fade_UI;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            Fade_UI.gameObject.SetActive(true);
        }
    }
}
