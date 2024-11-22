using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SetUpCamera : MonoBehaviour
{
    [SerializeField] private Camera Player1Camera;
    [SerializeField] private Camera Player2Camera;
    private PlayerInputManager _playerInputManager;

    private void Awake()
    {
        _playerInputManager = GetComponent<PlayerInputManager>();
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void Update()
    {
        int PlayerCount;
        PlayerCount = _playerInputManager.playerCount;
        
        if (PlayerCount == 2)
        {
            Player1Camera.rect = new Rect(0, 0.5f, 1, 0.5f);
            Player2Camera.rect = new Rect(0, 0, 1, 0.5f);
        }
        
        Debug.Log(PlayerCount);
    }
}
