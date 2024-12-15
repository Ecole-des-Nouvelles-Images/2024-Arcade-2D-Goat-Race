using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour
{

    [SerializeField] private GameObject _foretMap;
    [SerializeField] private GameObject _desetMap;

    [SerializeField] private List<GameObject> Bonus;
    private void Start()
    {
        if (GlobalVariable.GlobalNameMap == "ForetMap")
        {
            _foretMap.SetActive(true);
        }
        if (GlobalVariable.GlobalNameMap == "DesertMap")
        {
            _desetMap.SetActive(true);
        }
    }
}
