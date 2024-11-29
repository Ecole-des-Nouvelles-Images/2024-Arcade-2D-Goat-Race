using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_FirstSelected : MonoBehaviour
{
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private GameObject Button;
    private void OnEnable()
    {
        eventSystem.SetSelectedGameObject(Button.gameObject);
    }
}
