using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Julien.Scripts;
using Julien.Scripts.SelectionPlayer;
using UnityEngine;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{
    public static int IndexPlayer;
    [SerializeField] private List<GameObject> Players;
    [SerializeField] private GameObject _decompteHUD;
    public List<Sprite> DecompteSprites;

    [SerializeField] private bool _gameStarted = false;
    [SerializeField] private int _chronometer = 3;
    private void Start()
    {
        //CallDecompte();
        Players = new List<GameObject>();
    }

    private void Update()
    {
        if (IndexPlayer == PlayerSelectionController.NumberOfPlayerSelected && !_gameStarted)
        {
            _gameStarted = true;
            CallDecompte();
        }
    }

    public void CallDecompte()
    {
        StartCoroutine("Delay");
        _decompteHUD.SetActive(true);

        List<GameObject> players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        foreach (GameObject player in players)
        {
            if (_chronometer == 0)
            {
                player.GetComponent<Goat>().CanMove = true;
            }
        }
    }
    public IEnumerator Delay()
    {
        _decompteHUD.transform.DOScale(2, 0.9f);
        
        yield return new WaitForSeconds(1f);
        
        if (_chronometer == 0)
        {
            StartCoroutine("Destroy");
        }
        else
        {
            _decompteHUD.transform.localScale = new Vector3(1, 1, 1);

            Image image = _decompteHUD.GetComponent<Image>();
            image.sprite = DecompteSprites[_chronometer - 1];
            _chronometer--;
            
            CallDecompte();
        }
    }
    
    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(_decompteHUD.gameObject);
    }
    
}
