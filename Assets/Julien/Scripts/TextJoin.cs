using Julien.Scripts.SelectionPlayer;
using UnityEngine;

public class TextJoin : MonoBehaviour
{
   private void Update()
   {
      if (PlayerSelectionController.NumberOfPlayer == 4) Destroy(gameObject);
   }
}
