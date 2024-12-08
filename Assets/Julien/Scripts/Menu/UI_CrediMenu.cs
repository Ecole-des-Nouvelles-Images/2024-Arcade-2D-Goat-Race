using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CrediMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _credi;

    public void Return()
    {
        _mainMenu.SetActive(true);
        _credi.SetActive(false);
    }
}
