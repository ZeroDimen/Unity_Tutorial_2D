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
        
        public GameObject play_Obj;
        public GameObject intro_UI;
        public GameObject outtro_UI;
        
        public GameObject score_UI;
        public GameObject gameoverUI;
        public GameObject fadeUI;
        public GameObject videoPlayUI;
        
        public TMP_InputField inputField;
        public TextMeshProUGUI nameTextUI;

        public Button startButton;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            Cat_GameManager.DataInit(); // Score, Time 초기화하는 함수
            
            play_Obj.SetActive(false);
            intro_UI.SetActive(true);
            score_UI.SetActive(false);
            outtro_UI.SetActive(false);
            videoPlayUI.SetActive(false);
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
            Init();
            play_Obj.SetActive(true);
            score_UI.SetActive(true);
            intro_UI.SetActive(false);
            nameTextUI.text = inputField.text;
            Cat_GameManager.isPlay = true;
            soundManager.audioSource.Play();
        }
        
        public void Ending(bool isHappy)
        {
            outtro_UI.SetActive(true);
            fadeUI.SetActive(true);
            Cat_Controller.isEnding = true;
            
            cat.GetComponent<CircleCollider2D>().enabled = false; // 콜라이더 비활성화
        
            Color color = isHappy ? Color.white : Color.black;
            
            if (isHappy)
            {
                fadeUI.GetComponent<Cat_UIFade>().OnFade(3f, color);
            }
            else
            {
            
                gameoverUI.SetActive(true);
                fadeUI.GetComponent<Cat_UIFade>().OnFade(3f, color);
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
            score_UI.SetActive(false);
            fadeUI.SetActive(false);
            gameoverUI.SetActive(false);
            soundManager.audioSource.Stop();
        }
    }
}
