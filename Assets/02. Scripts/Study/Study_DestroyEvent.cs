using UnityEngine;

// 생성된 오브젝트를 코드로 삭제하는 스크립트
public class Study_DestroyEvent : MonoBehaviour
{
    public float destroyTime = 3f;
    private void Start()
    {
        Destroy(this.gameObject, destroyTime); // 자기 자신을 destroyTime초 뒤에 파괴하는 기능
    }

    private void OnDestroy() // Destroy 함수가 작동하거나 유니티 실행이 종료 되었을대 작동하는 함수
    {
        Debug.Log($"{this.gameObject.name} is Destroyed");
    }
}
