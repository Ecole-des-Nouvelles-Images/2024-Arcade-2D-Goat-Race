using System;
using Julien.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndLine : MonoBehaviour
{
    public int MaxLaps;

    public int LapPlayerOne = 0;
    public int LapPlayerTwo = 0;
    public int LapPlayerThree = 0;
    public int LapPlayerFour = 0;

    public bool PlayerOneCanIncress;
    public bool PlayerTwoCanIncress;
    public bool PlayerThreeCanIncress;
    public bool PlayerFourCanIncress;
    private void Start()
    {
        if (GameObject.Find("Laps1") != null) GameObject.Find("Laps1").GetComponent<TMP_Text>().text = LapPlayerOne +"/" + MaxLaps;
        if (GameObject.Find("Laps2") != null) GameObject.Find("Laps2").GetComponent<TMP_Text>().text = LapPlayerTwo+"/" + MaxLaps;
        if (GameObject.Find("Laps3") != null) GameObject.Find("Laps3").GetComponent<TMP_Text>().text = LapPlayerThree+"/" + MaxLaps; 
        if (GameObject.Find("Laps4") != null) GameObject.Find("Laps4").GetComponent<TMP_Text>().text = LapPlayerFour+"/" + MaxLaps;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Goat>() != null)
        {
            if (other.gameObject.GetComponent<Goat>().PlayerNumber == 1 && PlayerOneCanIncress)
            {
                TMP_Text text = GameObject.Find("Laps1").GetComponent<TMP_Text>();
                LapPlayerOne++;
                text.text = LapPlayerOne +"/"+ MaxLaps;

                
                PlayerOneCanIncress = false;

                if (LapPlayerOne == MaxLaps)
                {
                    GameObject.Find("Timer1").GetComponent<Timer>().PlayTimer = false;
                }
            }
            
            if (other.gameObject.GetComponent<Goat>().PlayerNumber == 2 && PlayerTwoCanIncress)
            {
                TMP_Text text = GameObject.Find("Laps2").GetComponent<TMP_Text>();
                LapPlayerTwo++;
                text.text = LapPlayerTwo +"/"+ MaxLaps;

                
                PlayerTwoCanIncress = false;
                
                if (LapPlayerTwo == MaxLaps)
                {
                    GameObject.Find("Timer2").GetComponent<Timer>().PlayTimer = false;
                }
            }
            
            if (other.gameObject.GetComponent<Goat>().PlayerNumber == 3 && PlayerThreeCanIncress)
            {
                TMP_Text text = GameObject.Find("Laps3").GetComponent<TMP_Text>();
                LapPlayerThree++;
                text.text = LapPlayerThree +"/"+ MaxLaps;

                
                PlayerThreeCanIncress = false;
                
                if (LapPlayerThree == MaxLaps)
                {
                    GameObject.Find("Timer3").GetComponent<Timer>().PlayTimer = false;
                }
            }
            
            if (other.gameObject.GetComponent<Goat>().PlayerNumber == 4 && PlayerFourCanIncress)
            {
                TMP_Text text = GameObject.Find("Laps4").GetComponent<TMP_Text>();
                LapPlayerFour++;
                text.text = LapPlayerFour +"/"+ MaxLaps;

                
                PlayerFourCanIncress = false;
                
                if (LapPlayerFour == MaxLaps)
                {
                    GameObject.Find("Timer4").GetComponent<Timer>().PlayTimer = false;
                }
            }
        }
    }
}
