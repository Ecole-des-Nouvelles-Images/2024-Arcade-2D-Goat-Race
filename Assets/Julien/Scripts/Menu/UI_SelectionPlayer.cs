using System;
using Julien.Scripts.SelectionPlayer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_SelectionPlayer : MonoBehaviour
{
    public string NameSceneMenu;
    public string NameSceneToOpen;
    
    public void Play()
    {
        foreach (PlayerData data in PlayerInputGoatSelectionHandler.Instance.PlayerData)
        {
            if (data == null) return;
        }
        SceneManager.LoadScene(NameSceneToOpen);
    }
    public void Return()
    {
        Debug.Log("Return");
        SceneManager.LoadScene(NameSceneMenu);
        
        PlayerSelectionController.NumberOfPlayer = 0;
        PlayerSelectionController.NumberOfPlayerSelected = 0;
        GameManager1.IndexPlayer = 0;
    }
}
