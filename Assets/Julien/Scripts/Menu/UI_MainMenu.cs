using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class UI_MainMenu : MonoBehaviour
{
   [SerializeField] private GameObject MainMenu;
   [SerializeField] private GameObject SelectedMap;
   [FormerlySerializedAs("OprtionPanel")] [SerializeField] private GameObject OptionPanel;
   public void Play()
   {
      Debug.Log("Play");
      MainMenu.SetActive(false);
      SelectedMap.SetActive(true);
      
   }
   public void Options()
   {
      MainMenu.SetActive(false);
      OptionPanel.SetActive(true);
      Debug.Log("Options");
   }
   public void Quit()
   {
      Application.Quit();
   }
   public void Credit()
   {
      Debug.Log("Credit");
   }
}
