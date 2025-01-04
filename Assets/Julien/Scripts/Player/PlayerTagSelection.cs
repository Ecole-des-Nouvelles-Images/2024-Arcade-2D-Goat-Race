using System;
using System.Collections;
using System.Collections.Generic;
using Julien.Scripts;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerTagSelection : MonoBehaviour
{
    [SerializeField] private List<Sprite> PlayerNumberTagImage;
    [SerializeField] private GameObject _parent;
    private Image _image;
    private int _playerNumber;
    
    private void Start()
    {
        _image = gameObject.GetComponent<Image>();
        _playerNumber = _parent.GetComponent<Goat>().PlayerNummber;

        if (_playerNumber == 1)
        {
            _image.sprite = PlayerNumberTagImage[_playerNumber -= 1];
        }
        if (_playerNumber == 2)
        {
            _image.sprite = PlayerNumberTagImage[_playerNumber -= 1];
        }
        if (_playerNumber == 3)
        {
            _image.sprite = PlayerNumberTagImage[_playerNumber -= 1];
        }
        if (_playerNumber == 4)
        {
            _image.sprite = PlayerNumberTagImage[_playerNumber -= 1];
        }
    }
}
