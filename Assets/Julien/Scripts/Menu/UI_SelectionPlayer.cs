using Julien.Scripts.SelectionPlayer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_SelectionPlayer : MonoBehaviour
{
    public void Play()
    {
        if (PlayerSelectionController.NumberOfPlayerSelected == PlayerSelectionController.NumberOfPlayer)
        {
            Debug.Log("Play");
            SceneManager.LoadScene("Game");
        }
    }
    public void Return()
    {
        Debug.Log("Return");
        SceneManager.LoadScene("MainMenu");
    }
}
