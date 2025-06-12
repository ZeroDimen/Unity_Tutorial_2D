using TMPro;
using UnityEngine;

// 게임 플레이 시간 및 점수를 출력하는 스크립트
public class Cat_GameManager : MonoBehaviour
{
    public TextMeshProUGUI PlayTimeUI;
    public TextMeshProUGUI ScoreUI;
    
    public static float timer;
    public static int Score = 0; // 과일을 먹은 개수
    public static bool isPlay = false;

    private void Update()
    {
        if (isPlay) // Play중일때만 
        {
            timer += Time.deltaTime;
            PlayTimeUI.text = string.Format("플레이 시간 : {0:F1}", timer); // {0:F1} 소수점 한자리 까지만 출력
            ScoreUI.text = $"X {Score}";
        }
    }

    public static void DataInit() // 내부 변수가 모두 static이어야 static 함수 사용가능
    {
        // Score, Time 초기화하는 함수
        timer = 0;
        Score = 0;
    }
}
