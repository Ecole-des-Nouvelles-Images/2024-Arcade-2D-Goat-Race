using System;
using UnityEngine;

namespace Julien.Scripts
{
   public class TakeBonus : MonoBehaviour
   {
      
      private SongSFX _songSFX;
      private AudioSource _audioSource;
      private void Awake()
      {
         //_songSFX = GameObject.Find("SFXManager").GetComponent<SongSFX>();
         //_audioSource = GetComponent<AudioSource>();
      }
      
      private void OnTriggerStay2D(Collider2D other)
      { 
         if (other.gameObject.CompareTag("Player"))
         {
            InventaryBonus inventaryBonus = other.gameObject.GetComponent<InventaryBonus>();
         
            if (inventaryBonus.HaveBonus == false && inventaryBonus.IsUsingBonus == false)
            {
               inventaryBonus.HaveBonus = true;
               inventaryBonus.RandomBonus();
               Debug.Log("attrape le bonus");
               Destroy(gameObject);
            }
            else
            {
               
            }
         }
      }
   }
}
