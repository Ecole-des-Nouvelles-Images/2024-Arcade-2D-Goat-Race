using Julien.Scripts;
using UnityEngine;

public class CheckPointEnd : MonoBehaviour
{
    [SerializeField] private EndLine _endLine;
    private void Start()
    {
        _endLine = GameObject.Find("End").GetComponent<EndLine>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           int IndexPlayer = other.gameObject.GetComponent<Goat>().PlayerNumber;

           if (IndexPlayer == 1)
           {
               _endLine.PlayerOneCanIncress = true;
           }
           if (IndexPlayer == 2)
           {
               _endLine.PlayerTwoCanIncress = true;
           }
           if (IndexPlayer == 3)
           {
               _endLine.PlayerThreeCanIncress = true;
           }
           if (IndexPlayer == 4)
           {
               _endLine.PlayerFourCanIncress = true;
           }
        }
    }
}
