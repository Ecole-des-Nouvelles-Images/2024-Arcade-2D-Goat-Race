using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_OptionMenu : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject OptionsMenu;
    public void Return()
    {
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
}
