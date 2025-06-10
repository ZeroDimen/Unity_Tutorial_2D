using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Corutine을 사용한 함수를 반복호출하는 스크립트
public class Study_Corutine : MonoBehaviour
{
    public Image image;
    
    private void Start()
    {
        // StartCoroutine("CorutineA");
        // StartCoroutine(CorutineA());
        // Invoke("Stopmethod", 3f);
        
    }

    public void OnFade(float fadeTime ,Color c)
    {
        StartCoroutine(Fade_Image(fadeTime ,c));
    }

    IEnumerator Fade_Image(float fadeTime, Color c)
    {
        float timer = 0f;
        float percent = 0f;
        
        while (percent <= 1f)
        {
            timer += Time.deltaTime; 
            percent = timer / fadeTime; // fade 퍼센트
            image.color = new Color(c.r, c.g, c.b,  percent);
            yield return null;
        }
        
    }
    
    IEnumerator CorutineA()
    {
        // yield return null; // Corutine에서 꼭 필요한 코드, 한개 프레임 대기
        yield return new WaitForSeconds(2f); // 2초 대기
        Debug.Log("Corutine 실행");
    }

    private void Stopmethod()
    { 
        StopCoroutine("CorutineA");
        // StopCoroutine(CorutineA()); X
        // StopAllCoroutines(); // 코드상에 있는 모든 Corutine 멈춤
    }
}
