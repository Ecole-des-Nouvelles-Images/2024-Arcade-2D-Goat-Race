using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursoManager : MonoBehaviour
{
   private void Start()
   {
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
   }
}
