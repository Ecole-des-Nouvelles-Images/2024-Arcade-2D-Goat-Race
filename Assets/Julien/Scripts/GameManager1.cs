using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    //[SerializeField] private GameObject Player1;
    //[SerializeField] private GameObject Player2;

    [SerializeField] private List<GameObject> Players;
    private void Update()
    {
        foreach (GameObject Player in Players)
        {
           float positionX = transform.position.x;
        }
    }
}
