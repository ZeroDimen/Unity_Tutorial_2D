using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Corutine을 사용한 함수를 반복호출하는 스크립트
public class Study_Corutine : MonoBehaviour
{
    public Image image;
    
    public float fadeTime = 2f;

    public bool isFadeIn = false;
    private void Start()
    {
        // StartCoroutine("CorutineA");
        // StartCoroutine(CorutineA());
        // Invoke("Stopmethod", 3f);
        StartCoroutine(Fade_Out_Image());
    }
    
    IEnumerator Fade_In_Image()
    {
        float timer = 0f;
        float percent = 0f;
        
        while (percent <= 1f)
        {
            timer += Time.deltaTime; 
            percent = timer / fadeTime; // fade 퍼센트
            image.color = new Color(image.color.r, image.color.g, image.color.b, percent);
            yield return null;
        }
        
    }
    
    IEnumerator Fade_Out_Image()
    {
        float timer = 0f;
        float percent = 0f;
        
        while (percent <= 1f)
        {
            timer += Time.deltaTime; 
            percent = timer / fadeTime; // fade 퍼센트
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1 - percent);
            yield return null;
        }
        
    }
    
    IEnumerator Fade_InOut_Image()
    {
        float timer = 0f;
        float percent = 0f;
        
        float value = isFadeIn ? percent : 1 - percent;
        while (percent <= 1f)
        {
            timer += Time.deltaTime; 
            percent = timer / fadeTime; // fade 퍼센트
            image.color = new Color(image.color.r, image.color.g, image.color.b, value);
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
