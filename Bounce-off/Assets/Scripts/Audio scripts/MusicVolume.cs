using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{

    public Slider slider;
    public AudioMixer mixer;
    //float sliderValue;
    
    private void Start()
    {
        PlayerPrefs.GetFloat("BackgroundMusicVolume", 0.75f);
    }
    public void SetAudioLevel(float sliderValue)
    {
        mixer.SetFloat("BackgroundMusicVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("BackgroundMusicVolume", sliderValue);
    }
}