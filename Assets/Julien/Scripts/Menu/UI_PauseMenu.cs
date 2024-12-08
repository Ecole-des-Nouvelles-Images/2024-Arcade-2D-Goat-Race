using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _optionMenu;

    public void Return()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void OpenOptionMenu()
    {
        _pauseMenu.SetActive(false);
        _optionMenu.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}
