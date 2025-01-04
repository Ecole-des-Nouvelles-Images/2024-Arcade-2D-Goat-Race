using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Julien.Scripts
{
   public class TakeBonus : MonoBehaviour
   {
      
      private SongSFX _songSFX;
      private AudioSource _audioSource;

      private bool _canBeTake = true;
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
               if (_canBeTake)
               {
                  inventaryBonus.HaveBonus = true;
                  inventaryBonus.RandomBonus();
                  Debug.Log("attrape le bonus");
                  StartCoroutine("Delay");
                  _canBeTake = false;
                  gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
               }
            }
            else
            {
               
            }
         }
      }

      public IEnumerator Delay()
      {
         yield return new WaitForSeconds(5f);
         gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
         _canBeTake = true;
      }
   }
}
