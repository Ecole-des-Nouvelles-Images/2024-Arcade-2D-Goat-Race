using System;
using Julien.Scripts;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
   [SerializeField] private Player _player;

   private void Awake()
   {
      _player = transform.parent.gameObject.GetComponent<Player>();
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Ground")) _player.CanJump = true;
      Debug.Log("Enter collider");
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Ground")) _player.CanJump = false;
      Debug.Log("Exit collider");
   }
}
