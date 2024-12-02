
using Julien.Scripts;
using UnityEngine;

public class EndGame : MonoBehaviour
{

    [SerializeField] private GameObject VictoryPanel;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.gameObject.CompareTag("Player"))
        {
            Goat goat = other.gameObject.GetComponent<Goat>();
        
            if (goat.PlayerOne)
            {
                Debug.Log("player 1 won");
                VictoryPanel.SetActive(true);
            }
            else
            {
                Debug.Log("player 2 won");
                VictoryPanel.SetActive(true);
            } 
        }
    }
}
