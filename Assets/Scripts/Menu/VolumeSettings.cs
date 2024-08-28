using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider; // Corrected variable name

    private void Start()
    {
        InitializeSliders();
        SetMasterVolume();
        SetMusicVolume();
        SetSFXVolume();
    }

    private void InitializeSliders()
    {
        float volume;
        if (myMixer.GetFloat("master", out volume))
        {
            masterSlider.value = Mathf.Pow(10, volume / 20);
        }
        if (myMixer.GetFloat("music", out volume))
        {
            musicSlider.value = Mathf.Pow(10, volume / 20);
        }
        if (myMixer.GetFloat("SFX", out volume))
        {
            SFXSlider.value = Mathf.Pow(10, volume / 20);
        }
    }

    public void SetMasterVolume()
    {
        float volume = Mathf.Clamp(masterSlider.value, 0.0001f, 1f); // Ensure volume is not zero
        myMixer.SetFloat("master", Mathf.Log10(volume) * 20);
    }

    public void SetMusicVolume()
    {
        float volume = Mathf.Clamp(musicSlider.value, 0.0001f, 1f); // Ensure volume is not zero
        myMixer.SetFloat("music", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume()
    {
        float volume = Mathf.Clamp(SFXSlider.value, 0.0001f, 1f); // Ensure volume is not zero
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }
}
