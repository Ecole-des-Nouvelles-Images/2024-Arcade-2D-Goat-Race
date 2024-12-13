using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class UI_SelectGoatMenu : MonoBehaviour
{
    [SerializeField] private GameObject _selectGoat;
    [SerializeField] private GameObject SelectMapMenu;

    [SerializeField] private TextMeshProUGUI _text;
    
    [SerializeField] private bool _playerOneSelected;

    public void Return()
    {
        SelectMapMenu.gameObject.SetActive(true);
        _selectGoat.SetActive(false);
        
        _text.text = "Selection de chevre joueur 1";
        _playerOneSelected = false;
    }
    
    public void ChevreNaine()
    {
        if (_playerOneSelected == false)
        {
            GlobalVariable.GoatNamePlayer1 = new string("ChevreNaine");
            _playerOneSelected = true;
            Debug.Log(" Player 1 " + GlobalVariable.GoatNamePlayer1);
            
            _text.text = "Selection de chèvre joueur 2";
            
        }
        else
        {
            GlobalVariable.GoatNamePlayer2 = new string("ChevreNaine");
            _playerOneSelected = true;
            Debug.Log(" Player 2 " + GlobalVariable.GoatNamePlayer2);

            SceneManager.LoadScene("Game");
        }
    }

    public void GrandeChevre()
    {
        if (_playerOneSelected == false)
        {
            GlobalVariable.GoatNamePlayer1 = new string("GrandeChevre");
            _playerOneSelected = true;
            Debug.Log(" Player 1 " + GlobalVariable.GoatNamePlayer1);
            
            _text.text = "Selection de chèvre joueur 2";
        }
        else
        {
            GlobalVariable.GoatNamePlayer2 = new string("GrandeChevre");
            _playerOneSelected = true;
            Debug.Log(" Player 2 " + GlobalVariable.GoatNamePlayer2);
            
            SceneManager.LoadScene("Game");
        }
    }
}
