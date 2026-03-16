using UnityEngine;

public class GroundChecker : MonoBehaviour
{
   public Player Player;

   private void Awake()
   {
      Player = transform.parent.gameObject.GetComponent<Player>();
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Ground")) Player.CanJump = true;
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Ground")) Player.CanJump = false;
   }
}
