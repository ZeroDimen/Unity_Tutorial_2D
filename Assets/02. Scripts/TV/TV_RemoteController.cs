using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

// TV 오브젝트를 관리하기 위한 스크립트
public class TV_RemoteController : MonoBehaviour
{
    public GameObject videoScreen;
    public Button[] Button_UI; // 버튼 배열

    public VideoClip[] videoClips; // 영상 배열

    private VideoPlayer videoPlayer;

    private bool isMute;
    private bool isOn;

    private int currentClipIndex;

    private void Awake()
    {
        isOn = videoScreen.activeSelf; // videoScreen 오브젝트가 켜져있는지 확인하는 함수
    }

    private void Start()
    {
        currentClipIndex = 0;
        videoPlayer = videoScreen.GetComponent<VideoPlayer>();
        Button_UI[0].onClick.AddListener(OnScreenPower);
        Button_UI[1].onClick.AddListener(OnMute);
        // Button_UI[2].onClick.AddListener(OnChangeChannel(true)); // 매개 변수있는 상태로 AddListener 사용이힘듬
        // Button_UI[3].onClick.AddListener(OnChangeChannel(false));
        
        Button_UI[2].onClick.AddListener(() => OnChangeChannel(true)); // Delegate 방식을 사용하면 해결가능
        Button_UI[3].onClick.AddListener(() => OnChangeChannel(false)); 

    }

    public void OnScreenPower() // TV의 전원을 끄거나 키는 함수
    {
        isOn = !isOn;
        videoScreen.SetActive(isOn);
        // if (isOn)
        // {
        //     isOn = false;
        //       videoScreen.SetActive(false);
        // }
        // else
        // {
        //     isOn = true;
        //       videoScreen.SetActive(true);
        // }
    }

    public void OnMute() // TV의 소리를 음소거 하는 함수
    {
        isMute = !isMute;
        videoPlayer.SetDirectAudioMute(0, isMute);
    }

    public void OnChangeChannel(bool isNext)  // TV의 채널을 변경하는 함수
    {
        if (isNext)
        {
            currentClipIndex++;
            if (currentClipIndex > videoClips.Length - 1)
            {
                currentClipIndex = 0;
            }
        }
        else
        {
            currentClipIndex--;
            if (currentClipIndex < 0)
            {
                currentClipIndex = videoClips.Length - 1;
            }
        }
        
        videoPlayer.clip = videoClips[currentClipIndex];
        videoPlayer.Play();
    }
}
