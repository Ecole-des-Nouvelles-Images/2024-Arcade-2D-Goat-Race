using System;
using Julien.Scripts.SelectionPlayer;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Julien.Scripts.Player
{
    public class PlayerSpawnHandler : MonoBehaviour
    {
        private PlayerInputManager _playerInputManager;
        [SerializeField] private int _playerNumber;
        
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

        private void OnPlayerJoined(PlayerInput playerInput)
        {
            int targer = playerInput.devices[0].deviceId;
            _playerNumber = PlayerSelectionController.DevicesID.IndexOf(targer);
            
            if (_playerNumber == 0)
            {
                playerInput.gameObject.GetComponent<Goat>().GoatData = PlayerSelectionController.ScriptableobjectPlayerOne;
                Debug.Log(" Player One " + PlayerSelectionController.ScriptableobjectPlayerOne);
            }
            if (_playerNumber == 1)
            {
                playerInput.gameObject.GetComponent<Goat>().GoatData = PlayerSelectionController.ScriptableobjectPlayerTwo;
                Debug.Log(" Player Two " + PlayerSelectionController.ScriptableobjectPlayerTwo);
            }
            if (_playerNumber == 2)
            {
                Debug.Log(" Player Three ");
                // ScriptableObjectDansPrefab = PlayerSelectionController.ScriptableobjectPlayerOne;
            }
            if (_playerNumber == 3)
            {
                Debug.Log(" Player Four ");
                // ScriptableObjectDansPrefab = PlayerSelectionController.ScriptableobjectPlayerOne;
            }
            Debug.Log("Joined");
        }
    }
}
