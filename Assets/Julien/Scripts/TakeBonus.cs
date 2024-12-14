using UnityEngine;

namespace Julien.Scripts
{
   public class TakeBonus : MonoBehaviour
   {
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
