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
        GlobalVariable.GlobalNameMap = new string("ForetMap");
        Debug.Log(GlobalVariable.GlobalNameMap);
        
        _selectGoatMenu.SetActive(true);
        _selectMapMenu.SetActive(false);

        //Scene.SceneManager.LoadScene("Game");
    }
    
    public void LoadDesertMap()
    {
        GlobalVariable.GlobalNameMap = new string("DesertMap");
        Debug.Log(GlobalVariable.GlobalNameMap);
        
        _selectGoatMenu.SetActive(true);
        _selectMapMenu.SetActive(false);
        
        //Scene.SceneManager.LoadScene("Game");
    }
}
