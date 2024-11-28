using System;
using System.Collections;
using System.Collections.Generic;
using Julien.Scripts;
using UnityEngine;

public class StunPlayer : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      Goat goat = other.GetComponent<Goat>();
      Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
    
      //rb.AddForce(0,0,2,ForceMode2D.Impulse);
      goat.Speed -= goat.Speed + goat.GoatData.Speed;
      Debug.Log("toucher");
    }
  }
}
