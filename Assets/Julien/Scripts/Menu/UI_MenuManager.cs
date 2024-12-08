using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    public void OpenPauseMenu()
    {
      _pauseMenu.SetActive(true);
      Time.timeScale = 0f;
      Debug.Log("OpenMenu");
    }
}
