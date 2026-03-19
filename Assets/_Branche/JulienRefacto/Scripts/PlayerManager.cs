using System;
using System.Collections.Generic;
using Julien.Scripts.SelectionPlayer;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    
    public PlayerInput[] PlayerInputs;
    public Player[] Players;
    public List<PlayerData> PlayerData = new List<PlayerData>();

    private void Awake()
    {
        DontDestroyOnLoad(this);
        Instance =  this;
    }

    private void Start()
    {
        AssignDataToPlayer();
        AssignGamePad();
    }

    private void AssignDataToPlayer()
    {
        PlayerData = PlayerInputGoatSelectionHandler.Instance.PlayerData;
        for (int i = 0; i < Players.Length; i++)
        {
            Players[i].GetComponent<Player>().PlayerData =  PlayerData[i];
        }
    }

    private void AssignGamePad()
    {
        var gamepad = Gamepad.all;
        
        for (int i = 0; i < PlayerInputs.Length; i++)
        {
            if (i < gamepad.Count)
            {
                PlayerInputs[i].SwitchCurrentControlScheme(gamepad[i]);
                Players[i].gameObject.SetActive(true);
                //Players[i].GetComponent<Player>().PlayerData = PlayerData[i];
            }
        }
    }
}
