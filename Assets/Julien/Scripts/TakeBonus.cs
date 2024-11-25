using UnityEngine;

namespace Julien.Scripts
{
   public class TakeBonus : MonoBehaviour
   {
      private void OnTriggerEnter2D(Collider2D other)
      {
         if (other.gameObject.CompareTag("Player"))
         {
            InventaryBonus inventaryBonus = other.gameObject.GetComponent<InventaryBonus>();
         
            if (inventaryBonus.HaveBonus == false)
            {
               inventaryBonus.HaveBonus = true;
               inventaryBonus.RandomBonus();
               Debug.Log("prend le bonus");
               Destroy(gameObject);
            }
            else
            {
               Debug.Log("Est full");
            }
         }
      }
   }
}
