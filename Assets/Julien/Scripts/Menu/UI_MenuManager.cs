using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    public static bool MenuOpened = false;
    
    public void OpenPauseMenu()
    {
        if (!MenuOpened)
        { 
            _pauseMenu.SetActive(true); 
            Time.timeScale = 0f;
            
            MenuOpened = true;
        }
    }
}
