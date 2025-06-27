using System;
using UnityEngine;
using UnityEngine.UI;

public class Knight_SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgmAudioSource;
    [SerializeField] private AudioSource sfxAudioSource;
    
    [SerializeField] private AudioClip[] bgmClips;
    [SerializeField] private AudioClip[] sfxClips;
    
    
    [SerializeField] private Slider bgmVolume;
    [SerializeField] private Slider sfxVolume;
    
    [SerializeField] private Toggle bgmMute;
    [SerializeField] private Toggle sfxMute;

    private void Awake()
    {
        bgmVolume.value = bgmAudioSource.volume;
        sfxVolume.value = sfxAudioSource.volume;
        
        bgmMute.isOn = bgmAudioSource.mute;
        sfxMute.isOn = sfxAudioSource.mute;
    }

    void Start()
    {
        BgmsoundPlay("Town BGM");
        
        bgmVolume.onValueChanged.AddListener(OnBGMVolumeChanged);
        sfxVolume.onValueChanged.AddListener(OnSFXVolumeChanged);
        
        bgmMute.onValueChanged.AddListener(OnBGMMute);
        sfxMute.onValueChanged.AddListener(OnSFXMute);
    }

    public void BgmsoundPlay(string clipName)
    {
        foreach (var clip in bgmClips)
        {
            if (clip.name == clipName)
            {
                bgmAudioSource.clip = clip;
                bgmAudioSource.Play();
                return;
            }
        }

        Debug.Log($" {clipName} not found");
    }


    public void EventsoundPlay(string clipName)
    {
        foreach (var clip in sfxClips)
        {
            if (clip.name == clipName)
            {
                sfxAudioSource.PlayOneShot(clip); // 실행하면 제어 X
                return;
            }
        }

        Debug.Log($" {clipName} not found");
    }

    private void OnBGMMute(bool isMute)
    {
        bgmAudioSource.mute = isMute;
    }
    
    private void OnSFXMute(bool isMute)
    {
        sfxAudioSource.mute = isMute;
    }

    private void OnBGMVolumeChanged(float volume)
    {
        bgmAudioSource.volume = volume;
    }
    
    private void OnSFXVolumeChanged(float volume)
    {
        sfxAudioSource.volume = volume;
    }
}
