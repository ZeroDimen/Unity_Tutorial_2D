using UnityEngine;

// 오브젝트 충돌로 인한 점수를 계산 및 출력하는 스크립트
public class PinBall_Score : MonoBehaviour
{
    public PinBall_Manager PB_Manager; // 유니티 상에서 할당 필요

    private void OnCollisionEnter2D(Collision2D other)
    {
        // if (other.collider.CompareTag("Score_10")) // if문으로 구현 (조건이 길면 가독성 증가)
        // {
        //     PB_Manager.Total_Score += 10;
        //     Debug.Log("Score 10 + ");
        // }
        // else if (other.collider.CompareTag("Score_30"))
        // {
        //     PB_Manager.Total_Score += 30;
        //     Debug.Log("Score 20 + ");
        // }
        // else if (other.collider.CompareTag("Score_50"))
        // {
        //     PB_Manager.Total_Score += 50;
        //     Debug.Log("score 50 + ");
        // }

        int Score = 0;
        switch (other.gameObject.tag) // switch문으로 구현 (코드가 길면 가독성 증가)
        {
            case "Score_10":
                Score = 10;
                break;
            case "Score_30":
                Score = 30;
                break;
            case "Score_50":
                Score = 50;
                break;
        }

        if (Score != 0)
        {
            PB_Manager.Total_Score += Score;
            Debug.Log($"Score: {Score}");
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GameOver"))
        {
            Debug.Log("--- Game Over ---");
            Debug.Log($"ToTal Score : {PB_Manager.Total_Score}");
            
        }
    }

}
