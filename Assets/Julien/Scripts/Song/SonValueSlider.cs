using System;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;

public class SonValueSlider : MonoBehaviour
{
     private static float _mainSoundSliderValue = 0.1f;
     private static float _musicSliderValue = 0.1f;
     private static float _sfxSliderValue = 0.1f;

    [SerializeField] private Slider _mainSoundSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;
    
    [SerializeField] private UI_OptionMenu _optionMenu;

    private void OnEnable()
    {
        _mainSoundSlider.value = _mainSoundSliderValue;
        _musicSlider.value = _musicSliderValue;
        _sfxSlider.value = _sfxSliderValue;
    }

    private void Start()
    {
        _mainSoundSliderValue = _mainSoundSlider.value;
        _musicSliderValue = _musicSlider.value;
        _sfxSliderValue = _sfxSlider.value;
    }

    private void Update()
    {
        _mainSoundSliderValue = _mainSoundSlider.value;
        _musicSliderValue = _musicSlider.value;
        _sfxSliderValue = _sfxSlider.value;
    }
}