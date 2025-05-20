using UnityEngine;

// 오브젝트를 키보드 W, A, S, D 키를 사용해 transform.position의 값을 변경하는 것으로 이동하는 기능을 담은 스크립트
public class Movement : MonoBehaviour
{
    public float Power;
    
    void Update()
    {
        // this. 생략 가능, 가독성을 위해 권장함
        // 기기 성능에 따라 실행되는 횟수가 다르므로 일관된 경험을 방지하기 위해
        // 한 프레임이 경과 한 시간을 가지는 Time.deltaTime을 곱하는 것으로 해결.
        {
            this.transform.position += Vector3.forward * (Power * Time.deltaTime); 
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += Vector3.left * (Power * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += Vector3.back * (Power * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += Vector3.right * (Power * Time.deltaTime);
        }
    }
}
