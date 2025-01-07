using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float CurrentTimer = 0;
    public bool PlayTimer = false;
    public TMP_Text TimerText;

    private void Start()
    {
        StartCoroutine("Delay");
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
        PlayTimer = true;
    }
    
    private void Update()
    {
        if(PlayTimer)
        {
            CurrentTimer += Time.deltaTime;
            int minutes = Mathf.FloorToInt(CurrentTimer / 60);
            int seconds = Mathf.FloorToInt(CurrentTimer % 60);
            int milliseconds = Mathf.FloorToInt((CurrentTimer * 100) % 100);
            TimerText.text = string.Format("{2:00} : {1:00} : {0:00} ",milliseconds, seconds, minutes);
        }
    }
}
