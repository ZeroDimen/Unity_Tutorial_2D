using UnityEngine;

// 오브젝트를 키보드 W, A, S, D 키를 사용해 transform.position의 값을 변경하는 것으로 이동하는 기능을 담은 스크립트
public class Movement : MonoBehaviour
{
    public float Power;
    
    void Update()
    {
        /*  this. 생략 가능, 가독성을 위해 권장함
            기기 성능에 따라 실행되는 횟수가 다르므로 일관된 경험을 방지하기 위해
            한 프레임이 경과 한 시간을 가지는 Time.deltaTime을 곱하는 것으로 해결.
            
         if (Input.GetKey(KeyCode.W))
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
        
            InPut System (Old - Legacy)
            입력값에 대한 약속된 시스템
            이동 -> WASD, 키보드 화살표
            점프 -> Space
            총쏘기 -> 마우스 왼쪽 
        
            딱 떨어지는 값 (-1, 0, 1)
            float h = Input.GetAxisRaw("Horizontal"); X 축
            float v = Input.GetAxisRaw("Vertical");  Z 축 */
        
        // 부드럽게 증감 (-1 ~ 1)
        float h = Input.GetAxis("Horizontal"); // X 축
        float v = Input.GetAxis("Vertical"); // Z 축
        
        Vector3 dir = new Vector3(h,0,v); // new Vector3(X,Y,Z);
        Vector3 normaldir = dir.normalized; // 대각이동시 속도값이 1 보다 커지는 것을 방지하기 위한 정규화 과정 ( 0 ~ 1 )

        // Debug.Log($"현제 입력 : {normaldir}");
        this.gameObject.transform.position += normaldir * (Power * Time.deltaTime);
        
        // transform.LookAt(Vector3 바라볼 좌표, Vector3 회전하는 방향);
        this.gameObject.transform.LookAt(transform.position + normaldir); // 오브젝트 바라보게 하는 함수
    }
}
