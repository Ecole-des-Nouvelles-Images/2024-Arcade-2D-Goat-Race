using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
   [SerializeField] private GameObject MainMenu;
   [SerializeField] private GameObject SelectedMap;
   public void Play()
   {
      Debug.Log("Play");
      MainMenu.SetActive(false);
      SelectedMap.SetActive(true);
      
   }
   public void Options()
   {
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
