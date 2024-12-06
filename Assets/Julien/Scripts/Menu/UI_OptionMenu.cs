using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class UI_OptionMenu : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject OptionsMenu;

    [SerializeField] private AudioMixer _audioMixer;
   
    [SerializeField] private Slider _mainSoundSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;
    public void Return()
    {
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
    
    public void MusicVolumeChange()
    {
        _audioMixer.SetFloat("MusicVol", Mathf.Log10(_musicSlider.value) * 20);
        if (_musicSlider.value == 0)
        {
            _audioMixer.SetFloat("MusicVol", -80f);
        }
    }
    
    public void SfxVolumeChange()
    {
        _audioMixer.SetFloat("SfxVol", Mathf.Log10(_sfxSlider.value) * 20);
        if (_sfxSlider.value == 0)
        {
            _audioMixer.SetFloat("SfxVol", -80f);
        }
    }
}
