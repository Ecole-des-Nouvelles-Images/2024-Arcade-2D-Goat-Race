using UnityEngine;
using Scene = UnityEngine.SceneManagement;

public class UI_SelectMapMenu : MonoBehaviour
{
    [SerializeField] private GameObject _selectMapMenu;
    [SerializeField] private GameObject _selectGoatMenu;
    [SerializeField] private GameObject _mainMenu;

    public string NameMap;
    public void Return()
    {
        _mainMenu.gameObject.SetActive(true);
        _selectMapMenu.SetActive(false);
    }

    public void LoadForetMap()
    {
        GlobalVariable.GlobalName = new string("ForêtMap");
        Debug.Log(GlobalVariable.GlobalName);
        
        _selectGoatMenu.SetActive(true);
        _selectMapMenu.SetActive(false);

        //Scene.SceneManager.LoadScene("Game");
    }
    
    public void LoadDesertMap()
    {
        GlobalVariable.GlobalName = new string("DesertMap");
        Debug.Log(GlobalVariable.GlobalName);
        
        _selectGoatMenu.SetActive(true);
        _selectMapMenu.SetActive(false);
        
        //Scene.SceneManager.LoadScene("Game");
    }
}
