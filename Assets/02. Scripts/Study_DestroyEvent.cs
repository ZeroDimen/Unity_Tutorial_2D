using UnityEngine;

public class Study_DestroyEvent : MonoBehaviour
{
    public float destroyTime = 3f;
    private void Start()
    {
        Destroy(this.gameObject, destroyTime); // 자기 자신을 3초 뒤에 파괴하는 기능
        
    }

    private void OnDestroy() // Destroy 함수가 작동하거나 유니티 실행이 종료 되었을대 작동하는 함수
    {
        Debug.Log($"{this.gameObject.name} is Destroyed");
    }
}
