using Julien.Scripts;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
   [SerializeField] private Goat _goat;
   
   private void OnTriggerStay2D(Collider2D other)
   {
      if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
      {
         _goat.CanJump = true;
      }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      _goat.CanJump = false;
   }
}
