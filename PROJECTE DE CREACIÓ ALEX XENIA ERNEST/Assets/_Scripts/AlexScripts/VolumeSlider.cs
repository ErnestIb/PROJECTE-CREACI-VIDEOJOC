using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] AudioMixer _AM;

    public void SetMusicVolume(float sliderValue) {_AM.SetFloat("MusicVolume",Mathf.Log10(sliderValue)*20);}

    public void SetSFXVolume(float sliderValue) {_AM.SetFloat("SFXVolume",Mathf.Log10(sliderValue)*20);}
        
}
