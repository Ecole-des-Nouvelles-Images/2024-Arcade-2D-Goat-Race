using DG.Tweening;
using Julien.Scripts;
using UnityEngine;

public class EndGame : MonoBehaviour
{

    [SerializeField] private GameObject VictoryPanelPlayerOne;
    [SerializeField] private GameObject VictoryPanelPlayerTwo;
    private bool _onePlayerWOn;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.gameObject.CompareTag("Player"))
        {
            Goat goat = other.gameObject.GetComponent<Goat>();

            if (_onePlayerWOn == false)
            {
                if (goat.PlayerOne)
                {
                    VictoryPanelPlayerOne.SetActive(true);
                    VictoryPanelPlayerOne.transform.DOScale(1, 0.2f);
                }
                else
                {
                    VictoryPanelPlayerTwo.SetActive(true);
                    VictoryPanelPlayerTwo.transform.DOScale(1, 0.2f);
                } 
            }
        }
    }
}
