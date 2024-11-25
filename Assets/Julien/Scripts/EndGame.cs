
using Julien.Scripts;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Goat goat = other.gameObject.GetComponent<Goat>();
        
        if (goat.PlayerOne )
        {
            Debug.Log("player 1 won");
        }
        else
        {
            Debug.Log("player 2 won"); 
        }
    }
}
