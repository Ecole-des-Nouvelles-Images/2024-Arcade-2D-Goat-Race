using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectionPlayerPanelManager : MonoBehaviour
{
    private PlayerInputManager _playerInputManager;
    public List<PlayerData> PlayerData = new List<PlayerData>();

    public static Action<Transform> OnPlayerJoin;
    
    private void Awake()
    {
        _playerInputManager = GetComponent<PlayerInputManager>();
    }

    private void OnEnable()
    {
        _playerInputManager.onPlayerJoined += OnPlayerJoined;
    }

    private void OnDisable()
    {
        _playerInputManager.onPlayerJoined -= OnPlayerJoined;
    }

    private void OnPlayerJoined(PlayerInput player)
    {
        PlayerData.Add(null);
    }
}
