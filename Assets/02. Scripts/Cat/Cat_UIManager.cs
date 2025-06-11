using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Cat 게임에서 UI 상호작용을 위한 스크립트
namespace Cat
{
    public class Cat_UIManager : MonoBehaviour
    {
        public Cat_SoundManager soundManager;
        public Cat_VideoManager videoManager;
        
        public GameObject cat;
        
        public GameObject Play_Obj;
        public GameObject Intro_Obj;
        
        public GameObject Play_UI;
        public GameObject GameoverUI;
        public GameObject FadeUI;
        
        public TMP_InputField inputField;
        public TextMeshProUGUI nameTextUI;

        public Button startButton;

        private void Awake()
        {
            Play_Obj.SetActive(false);
            Intro_Obj.SetActive(true);
            Play_UI.SetActive(false);
        }

        private void FixedUpdate() // 빈칸 입력이나 기본입력을 방지하기 위함
        {
            // if (inputField.text is "" or "고양이 이름을 정해주세요")
            if (inputField.text == "" || inputField.text == "고양이 이름을 정해주세요")
            {
                startButton.interactable = false;
            }
            else
            {
                startButton.interactable = true;
            }
        }

        public void OnStartButton()
        {
            Play_Obj.SetActive(true);
            Play_UI.SetActive(true);
            
            Intro_Obj.SetActive(false);
            nameTextUI.text = inputField.text;
            Cat_GameManager.isPlay = true;
        }
        
        public void Ending(bool isHappy)
        {
            FadeUI.SetActive(true);
            Play_UI.SetActive(false);
            cat.GetComponent<BoxCollider2D>().enabled = false; // 콜라이더 비활성화
        
            if (isHappy)
            {
                FadeUI.GetComponent<Study_Corutine>().OnFade(3f, Color.white);
            }
            else
            {
            
                GameoverUI.SetActive(true);
                FadeUI.GetComponent<Study_Corutine>().OnFade(3f, Color.black);
            }
            
            // Invoke("Video(Ending)",5f); Invoke로는 호출하는 함수에게 매개변수를 넘겨줄수없음
            // 따라서 매개변수를 사용하는 함수를 지연호출하기위해서는 Courutine을 사용해야함
            StartCoroutine(Video(isHappy,3f));
        }

        IEnumerator Video(bool isHappy,float delay)
        {
            yield return new WaitForSeconds(delay);
        
            if (isHappy)
            {
                videoManager.VideoPlay(true);
            }
            else
            {
                videoManager.VideoPlay(false);
            }
            
            // yield return new WaitUntil(()=> videoManager.videoPlayer.isPlaying); // 람다식
            FadeUI.SetActive(false);
            GameoverUI.SetActive(false);
            soundManager.audioSource.mute = true;
        }
    }
}
