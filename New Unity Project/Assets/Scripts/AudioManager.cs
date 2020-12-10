using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource effectSource;
    public AudioSource musicSource;

    public AudioClip menuMusic;
    public AudioClip effectClick;
    public AudioClip bosqueMusic;
    public Slider sliderMusic, sliderSFX;

  public void PlayEffect()
    {
        effectSource.PlayOneShot(effectClick);
    }
    public void PlaySong(AudioClip audioClip)
    {
        musicSource.clip = audioClip;
        musicSource.Play();
    }
    public void OnMusicVolumeUpdate()
    {
        musicSource.volume = sliderMusic.value;
    }
    public void OnSFXVolumeUpdate()
    {
        effectSource.volume = sliderSFX.value;
    }

}
