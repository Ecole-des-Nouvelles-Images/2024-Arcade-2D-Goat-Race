using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      Debug.Log("change le check point");
      other.gameObject.GetComponent<KillPlayer>().SpawnPosition = gameObject.transform.position;
    }
  }
}
