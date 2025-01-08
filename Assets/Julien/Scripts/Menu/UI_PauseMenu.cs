using Julien.Scripts.SelectionPlayer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _optionMenu;

    private bool _menuOpened;

    public void Return()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        
        UI_MenuManager.MenuOpened = false;
    }
    
    public void OpenOptionMenu()
    {
        _pauseMenu.SetActive(false);
        _optionMenu.SetActive(true);
    }

    public void MainMenu()
    {
        PlayerSelectionController.NumberOfPlayer = 0;
        PlayerSelectionController.NumberOfPlayerSelected = 0;
        GameManager1.IndexPlayer = 0;
        
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
        
        UI_MenuManager.MenuOpened = false;
    }
}
