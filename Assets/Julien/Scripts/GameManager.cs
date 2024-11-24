using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // faire une liste de preb, le 1 aurant la camera en haut et le 2 en bas

    public List<GameObject> PlayerPrefabs;

    private void Awake()
    {
        PlayerPrefabs = new List<GameObject>();
    }

    private void Update()
    {
       // PlayerPrefabs.Add(GameObject.FindWithTag("Player").gameObject);
    }

    public void AddTolist(GameObject Player)
    {
        if (Player != null)
        { 
            PlayerPrefabs.Add(Player);
        }
        else
        {
        }
    }
    
    public void SetUpCameraPlayer()
    {
        Camera camera;
        camera = PlayerPrefabs[0].gameObject.GetComponent<Camera>();
        camera.rect = new Rect(0, 0, 0, 0);
    }
}
