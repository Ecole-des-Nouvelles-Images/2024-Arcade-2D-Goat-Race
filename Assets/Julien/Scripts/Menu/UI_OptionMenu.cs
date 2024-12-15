using System;
using UnityEngine;
using UnityEngine.Audio;
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
    private void Update()
    {
        _audioMixer.SetFloat("MasterVol", Mathf.Log10(_mainSoundSlider.value) * 20);
        _audioMixer.SetFloat("MusicVol", Mathf.Log10(_musicSlider.value) * 20);
        _audioMixer.SetFloat("SfxVol", Mathf.Log10(_sfxSlider.value) * 20);
    }
}
