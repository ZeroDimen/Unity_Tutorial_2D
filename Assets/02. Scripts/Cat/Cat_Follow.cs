using UnityEngine;

// Cat의 명찰이 Cat의 Rotation에 영향을 받지 않게 하기위한 스크립트
public class Cat_Follow : MonoBehaviour
{
    public Transform Cat;
    public Vector3 offset;
    private void Update()
    {
        transform.position = Cat.position + offset;
    }
}
