using UnityEngine;

// 오브젝트를 움직여 반복되는 이미지를 만들기 위한 스크립트
public class Transform_LoopMap : MonoBehaviour
{
    public float Loop_Speed;
    
    private Vector3 Return_Pos;

    private void Update()
    {
        Image_Loop_DeltaTime();
        // Image_Loop_FixedDeltaTime();
    }

    private void Image_Loop_DeltaTime() // Time.deltaTime 값의 오차로 이동할 타이밍에 오차가 생김
    {
        this.gameObject.transform.Translate(Vector3.left * (Loop_Speed * Time.deltaTime)); 
        if (this.gameObject.transform.position.x <= -30f) // 오브젝트 x축 위치가 -30f 이하일경우
        {
            // 오브젝트 x축 위치를 30f로 이동
            // 해결방법: Time.deltaTime의 오차를 포함하는 좌표에 오브젝트 이동
            this.gameObject.transform.position = new Vector3(60f + this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f);
        }
    }

    private void Image_Loop_FixedDeltaTime() // 고정적인 값을 주는 Time.fixedDeltaTime을 사용하면 오차를 줄일 수 있음 
    {
        this.gameObject.transform.Translate(Vector3.left * (Loop_Speed * Time.fixedDeltaTime));
        
        if (this.gameObject.transform.position.x <= -30f)
        {
            this.gameObject.transform.position = new Vector3(30f, this.gameObject.transform.position.y, 0f);
        }
    }
}
