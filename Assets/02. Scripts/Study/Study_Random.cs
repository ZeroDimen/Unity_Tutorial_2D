using UnityEngine;

// Random.Range를 사용한 무작위 값을 가지는 스크립트
public class Study_Random : MonoBehaviour
{
    private void OnEnable()
    {
        // Random.Range(int 최솟값(포함), int 최댓값(미포함))
        // Random.Range(float 최솟값(포함), float 최댓값(포함))
        float RandomNumber = Random.Range(0, 100); 
        Debug.Log(RandomNumber);
    }
}
