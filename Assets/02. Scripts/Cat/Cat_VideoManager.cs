using UnityEngine;
using UnityEngine.Video;

namespace Cat
{
    public class Cat_VideoManager : MonoBehaviour
    {
        private VideoPlayer videoPlayer;
        
        public GameObject videoPanel;
        public VideoClip[] videoClip;

        void Start()
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        public void VideoPlay(bool isHappy)
        {
            var clip = isHappy ? videoClip[0] : videoClip[1];
            videoPlayer.clip = clip;
            videoPlayer.Play();
            videoPanel.SetActive(true);
        }
    }
}
