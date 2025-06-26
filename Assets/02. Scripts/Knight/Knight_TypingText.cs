using System.Collections;
using TMPro;
using UnityEngine;

// 타이핑 효과를 주기 위한 스크립트
public class Knight_TypingText : MonoBehaviour
{ 
    [SerializeField] private TextMeshProUGUI textUi;
    private string currText;
    [SerializeField] private float typingSpeed = 0.1f;

    private void OnEnable()
    {
        currText = textUi.text; // 유니티 상에 적힌 글씨를 저장
        textUi.text = string.Empty;
        StartCoroutine(TypingRoutine());
    }

    private void OnDisable() // 다시 초기화 해주지않으면 글이 짤림
    {
        textUi.text = currText;
    }
    

    IEnumerator TypingRoutine() 
    {
        int textCount = currText.Length;
        for (int i = 0; i < textCount; i++)
        {
            textUi.text += currText[i];
            yield return new WaitForSeconds(typingSpeed); 
        }
    }
}
