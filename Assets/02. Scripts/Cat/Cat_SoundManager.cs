using UnityEngine;

// 유니티에서 소리를 출력, 설정하는 스크립트
namespace  Cat
{
    public class Cat_SoundManager : MonoBehaviour
    {
        public AudioSource audioSource;
        public AudioClip Bgm_Intro_Clip;
        public AudioClip Bgm_Game_Clip;
        public AudioClip Jump_Clip;

        private void Start()
        {
            SetBGM_Intro_Sound();
        }

        public void SetBGM_Intro_Sound() // 인트로 배경음 출력함수
        {
            audioSource.clip = Bgm_Intro_Clip; // 오디오 소스에 사운드 파일 설정 
            audioSource.playOnAwake = true; // 시작할 때 자동 재생
            audioSource.loop = true; // 반복 기능
            audioSource.volume = 0.5f; // 소리 음량
            
            audioSource.Play(); // 시작
            // audioSource.Stop(); 정지 
            // audioSource.Pause(); 일시정지
        }

        public void SetBGM_Game_Sound() // 게임 배경음 출력함수
        {
            audioSource.clip = Bgm_Game_Clip;
            audioSource.Play(); // 시작
        }

        public void Set_GameOver_Sound()
        {
            audioSource.Stop();
        }
        public void OnJumpSound() // 점프 효과음 출력함수
        {
            // PlayOneShot(AudioClip.name) 한번 출력, 임시로 사용, 제어 불가 (클립을 매개변수로 사용)
            audioSource.PlayOneShot(Jump_Clip); // 설정 변경 불가 
        }
    }
}

