using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class UI_MainMenu : MonoBehaviour
{
   [SerializeField] private GameObject _mainMenu;
   [SerializeField] private GameObject _selectedMap;
   [SerializeField] private GameObject _credi;
   [SerializeField] private GameObject _optionPanel;
   public void Play()
   {
      Debug.Log("Play");
      _mainMenu.SetActive(false);
      _selectedMap.SetActive(true);
      
   }
   public void Options()
   {
      _mainMenu.SetActive(false);
      _optionPanel.SetActive(true);
      Debug.Log("Options");
   }
   public void Quit()
   {
      Application.Quit();
   }
   public void Credit()
   {
      _mainMenu.SetActive(false);
      _credi.SetActive(true);
   }
}
