using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlacement : MonoBehaviour
{
   [SerializeField] private GameObject Camera;
   [SerializeField] private Goat _goat;
   private void Update()
   {
      //float PositionCamZ = _goat.CameraDistance * 1.5f;
      //transform.position = new Vector3(0, 0, -PositionCamZ);
   }
}
