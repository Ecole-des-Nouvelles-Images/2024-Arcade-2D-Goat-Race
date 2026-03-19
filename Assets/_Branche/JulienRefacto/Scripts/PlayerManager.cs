using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    
    public PlayerInput[] PlayerInputs;
    public Player[] Players;
    public List<PlayerData> PlayerData;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        Instance =  this;
    }

    private void Start()
    {
        AssignGamePad();
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
