using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] ParallaxData parallaxData;

    [SerializeField] private GameObject Plan1;
    [SerializeField] private GameObject Plan2;
    [SerializeField] private GameObject Plan3;
    [SerializeField] private GameObject Plan4;
    
    [SerializeField] private Sprite _sprite1;
    [SerializeField] private Sprite _sprite2;
    [SerializeField] private Sprite _sprite3;
    [SerializeField] private Sprite _sprite4;

    private void Start()
    {
        _sprite1 = parallaxData.Sprite1;
        _sprite2 = parallaxData.Sprite2;
        _sprite3 = parallaxData.Sprite3;
        _sprite4 = parallaxData.Sprite4;
        
        Plan1.GetComponent<SpriteRenderer>().sprite = _sprite1;
        Plan2.GetComponent<SpriteRenderer>().sprite = _sprite2;
        Plan3.GetComponent<SpriteRenderer>().sprite = _sprite3;
        Plan4.GetComponent<SpriteRenderer>().sprite = _sprite4;
    }
}
