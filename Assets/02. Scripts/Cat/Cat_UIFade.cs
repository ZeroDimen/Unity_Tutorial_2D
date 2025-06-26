using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Corutine을 사용한 함수를 반복호출하는 스크립트
public class Cat_UIFade : MonoBehaviour // UIManager에서 처리하는게 좋을지도?
{
    public Image image;

    private void OnEnable()
    {
        this.image.color = new Color(0, 0, 0, 0);
    }

    public void OnFade(float fadeTime ,Color c)
    {
        StartCoroutine(Fade_Image(fadeTime ,c, true));
    }

    public IEnumerator Fade_Image(float fadeTime, Color c , bool isFade) // Knight 씬에서도 사용하기위해 public
    {
        float timer = 0f;
        float percent = 0f;
        
        while (percent <= 1f)
        {
            timer += Time.deltaTime; 
            percent = timer / fadeTime; // fade 퍼센트

            float value = isFade ? percent : 1 - percent;
            
            image.color = new Color(c.r, c.g, c.b,  value);
            yield return null;
        }
    }
}