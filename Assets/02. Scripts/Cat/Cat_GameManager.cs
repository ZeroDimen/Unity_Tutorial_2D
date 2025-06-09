using TMPro;
using UnityEngine;

// 게임 플레이 시간을 출력하는 스크립트
public class Cat_GameManager : MonoBehaviour
{
    public TextMeshProUGUI PlayTimeUI;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        // PlayTimeUI.text = timer.ToString();
        PlayTimeUI.text = string.Format("플레이 시간 : {0:F1}", timer); // {0:F1} 소수점 한자리 까지만 출력
    }
}
