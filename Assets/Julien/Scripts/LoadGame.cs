using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour
{

    [SerializeField] private GameObject _foretMap;
    [SerializeField] private GameObject _desetMap;
    private void Start()
    {
        if (GlobalVariable.GlobalNameMap == "ForêtMap")
        {
            _foretMap.SetActive(true);
            Debug.Log("Map Foret");
        }
        if (GlobalVariable.GlobalNameMap == "DesertMap")
        {
            _desetMap.SetActive(true);
            Debug.Log("Map Foret");
        }
    }
}
