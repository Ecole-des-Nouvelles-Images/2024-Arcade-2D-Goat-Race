using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{

   [SerializeField] private Goat _goat;
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.tag == "Ground")
      {
         _goat.CanJump = true;
      }
      else
      {
         _goat.CanJump = false;
      }
   }
}
