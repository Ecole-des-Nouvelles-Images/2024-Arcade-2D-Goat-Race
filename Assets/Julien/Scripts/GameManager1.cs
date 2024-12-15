using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
    
    // private int _chronometer = 3;
    // private void Start()
    // {
    //     CallDecompte();   
    //
    //     foreach (GameObject player in Players)
    //     {
    //        player.gameObject.GetComponent<Goat>().CanMove =  false;
    //     }
    // }
    //
    // public void CallDecompte()
    // {
    //     StartCoroutine("Delay");
    // }
    // public IEnumerator Delay()
    // {
    //     _decompteHUD.transform.DOScale(2, 0.9f);
    //     
    //     yield return new WaitForSeconds(1f);
    //     
    //     _decompteHUD.transform.localScale = new Vector3(1, 1, 1);
    //     
    //     Image image = _decompteHUD.GetComponent<Image>();
    //     image.sprite = DecompteSprites[_chronometer - 1];
    //     _chronometer -= 1;
    //     
    //     if (_chronometer == 0)
    //     {
    //         StartCoroutine("Destroy");
    //         foreach (GameObject player in Players)
    //         {
    //             player.gameObject.GetComponent<Goat>().CanMove =  true;
    //         }
    //     }
    //     else
    //     {
    //         CallDecompte();
    //     }
    // }
    //
    // private IEnumerator Destroy()
    // {
    //     yield return new WaitForSeconds(1f);
    //     Destroy(_decompteHUD.gameObject);
    // }
    //
    // private void Update()
    // {
    //     foreach (GameObject Player in Players)
    //     {
    //        float positionX = transform.position.x;
    //     }
    // }
}
