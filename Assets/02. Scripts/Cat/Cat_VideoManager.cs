using UnityEngine;
using UnityEngine.Video;

namespace Cat
{
    public class Cat_VideoManager : MonoBehaviour
    {
        public VideoPlayer videoPlayer;
        
        public GameObject videoPanel;
        public VideoClip[] videoClip;

        void Start()
        {
            videoPanel.SetActive(false);
            videoPlayer = GetComponent<VideoPlayer>();
        }

        public void VideoPlay(bool isHappy)
        {
            videoPanel.SetActive(true);
            var clip = isHappy ? videoClip[0] : videoClip[1];
            videoPlayer.clip = clip;
            videoPlayer.Play();
        }
    }
}
