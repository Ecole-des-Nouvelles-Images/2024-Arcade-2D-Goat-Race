using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UI_SelectGoatMenu : MonoBehaviour
{
    [SerializeField] private GameObject _selectGoatPlayer1;
    [SerializeField] private GameObject SelectMapMenu;
    [SerializeField] private GameObject _selectGoatPlayer2;
    
    public void Return()
    {
        SelectMapMenu.gameObject.SetActive(true);
        _selectGoatPlayer1.SetActive(false);
    }

    public void ChevreNaine()
    {
        GlobalVariable.GoatNamePlayer1 = new string("ChevreNaine");
        
    }

    public void GrosseChevre()
    {
        GlobalVariable.GoatNamePlayer1 = new string("GrosseChevre");
    }
}
