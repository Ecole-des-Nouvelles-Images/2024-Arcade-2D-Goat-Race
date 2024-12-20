using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Selected : MonoBehaviour
{
   private GameObject _eventSystemGameObject;
   private EventSystem _eventSystem;

   private ButtonSelectGoat _buttonSelectGoat;
   private void Awake()
   {
      _eventSystemGameObject = GameObject.Find("EventSystem");
      _eventSystem = _eventSystemGameObject.GetComponent<EventSystem>();

      _buttonSelectGoat = gameObject.GetComponent<ButtonSelectGoat>();
   }
}
