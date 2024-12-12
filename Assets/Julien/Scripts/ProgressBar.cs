using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private GameObject _final;

    [SerializeField] private GameObject PlayerTarget;
    [SerializeField] private Slider _slider;

    private float PositionX;

    private void Start()
    {
        PositionX = _final.transform.position.x;
    }

    private void Update()
    {
        float PlayerPositionX = PlayerTarget.transform.position.x;
        float result = (PlayerPositionX/PositionX) * 100;
        
        _slider.value = result/100f;
        Debug.Log(result);
    }
}
