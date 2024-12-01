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
        Debug.Log(GlobalVariable.GlobalName);
        if (GlobalVariable.GlobalName == "ForêtMap")
        {
            _foretMap.SetActive(true);
            Debug.Log("Map Foret");
        }
        if (GlobalVariable.GlobalName == "DesertMap")
        {
            _desetMap.SetActive(true);
            Debug.Log("Map Foret");
        }
    }
}
