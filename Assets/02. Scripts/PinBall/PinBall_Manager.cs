using UnityEngine;


// 핀볼 게임을 위한 핀볼 바 오브젝트를 키보드 입력으로 회전하는 스크립트
public class PinBall_Manager : MonoBehaviour
{
    public Rigidbody2D Left_Bar_Rb;
    public Rigidbody2D Right_Bar_Rb;

    public int Total_Score = 0;
    public void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Left_Bar_Rb.AddTorque(30f); // AddTorque(float 회전힘, mode)
        }
        else
        {
            Left_Bar_Rb.AddTorque(-25f);
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Right_Bar_Rb.AddTorque(-30f);
        }
        else
        {
            Right_Bar_Rb.AddTorque(25f);
        }
    }
}
