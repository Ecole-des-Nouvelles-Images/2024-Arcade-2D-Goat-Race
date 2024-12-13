using Julien.Scripts;
using UnityEngine;

public class EndGame : MonoBehaviour
{

    [SerializeField] private GameObject VictoryPanelPlayerOne;
    [SerializeField] private GameObject VictoryPanelPlayerTwo;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.gameObject.CompareTag("Player"))
        {
            Goat goat = other.gameObject.GetComponent<Goat>();
        
            if (goat.PlayerOne)
            {
                Debug.Log("player 1 won");
                VictoryPanelPlayerOne.SetActive(true);
            }
            else
            {
                Debug.Log("player 2 won");
                VictoryPanelPlayerTwo.SetActive(true);
            } 
        }
    }
}
