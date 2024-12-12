using System;
using System.Collections;
using System.Collections.Generic;
using Julien.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{
    //[SerializeField] private GameObject Player1;
    //[SerializeField] private GameObject Player2;

    [SerializeField] private List<GameObject> Players;
    [SerializeField] private GameObject _decompteHUD;
    public List<Sprite> DecompteSprites;
    
    private int _chronometer = 3;
    private void Start()
    {
        CallDecompte();   
        Debug.Log(_chronometer);

        foreach (GameObject player in Players)
        {
           player.gameObject.GetComponent<Goat>().CanMove =  false;
        }
    }

    public void CallDecompte()
    {
        StartCoroutine("Delay");
    }
    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        Image image = _decompteHUD.GetComponent<Image>();
        image.sprite = DecompteSprites[_chronometer - 1];
        _chronometer -= 1;
        Debug.Log(_chronometer);
        if (_chronometer == 0)
        {
            Debug.Log("game start");
            
            foreach (GameObject player in Players)
            {
                player.gameObject.GetComponent<Goat>().CanMove =  true;
            }
        }
        else
        {
            CallDecompte();
        }
    }

    private void Update()
    {
        foreach (GameObject Player in Players)
        {
           float positionX = transform.position.x;
        }
    }
}
