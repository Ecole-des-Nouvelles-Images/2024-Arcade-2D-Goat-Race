using System.Collections.Generic;
using Julien.Scripts.SelectionPlayer;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    
    public PlayerInput[] PlayerInputs;
    public Player[] Players;
    
    [SerializeField] private List<PlayerData> _datas = new List<PlayerData>();
    public static List<PlayerData> PlayerData = new List<PlayerData>();

    private void Awake()
    {
        _datas = PlayerData;
        Instance =  this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        AssignDataToPlayer();
        //ActivePlayer();
        for (int i = 0; i < PlayerInputs.Length; i++)
        {
            var devices = PlayerInputs[i].devices;
            if (devices.Count > 0)
            {
                Debug.Log($"Player {i} → {devices[0].displayName}");
            }
        }
        AssignGamePad();
    }

    private void AssignDataToPlayer()
    {
        //PlayerData = PlayerInputGoatSelectionHandler.Instance.PlayerData;
        for (int i = 0; i < _datas.Count; i++)
        {
            Players[i].GetComponent<Player>().PlayerData =  _datas[i];
        }
    }

    private void AssignGamePad()
    {
        var gamepad = Gamepad.all;
        
        for (int i = 0; i < _datas.Count; i++)
        {
            if (i < gamepad.Count)
            {
                PlayerInputs[i].SwitchCurrentControlScheme(gamepad[i]);
                Players[i].gameObject.SetActive(true);
            }
        }
    }
}
