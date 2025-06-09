using UnityEngine;

// 오브젝트를 움직여 반복되는 이미지를 만들기 위한 스크립트
public class Transform_LoopObject : MonoBehaviour
{
    public float Loop_Speed;
    public float Return_Pos_X;
    private float Random_Pos_Y;
    private void Update()
    {
        gameObject.transform.Translate(Vector3.left * (Loop_Speed * Time.deltaTime)); 
        if (gameObject.transform.position.x <= -Return_Pos_X) // 오브젝트 x축 위치가 -Return_Pos.x 이하일경우
        {
            Random_Pos_Y = Random.Range(-8f, -4.5f);
            // 오브젝트 x축 위치를 -Return_Pos.x로 이동
            // 해결방법: Time.deltaTime의 오차를 포함하는 좌표에 오브젝트 이동
            gameObject.transform.position = new Vector3(Return_Pos_X * 2 + gameObject.transform.position.x, Random_Pos_Y, 0f);
        }
    }
}