using Julien.Scripts.SelectionPlayer;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Julien.Scripts.Player
{
    public class PlayerSpawnHandler : MonoBehaviour
    {
        private PlayerInputManager _playerInputManager;

        private void Awake()
        {
            _playerInputManager = GetComponent<PlayerInputManager>();
        }

        private void OnEnable()
        {
            _playerInputManager.onPlayerJoined += OnPlayerJoined;
            Debug.Log("Joined");
        }

        private void OnDisable()
        {
            _playerInputManager.onPlayerJoined -= OnPlayerJoined;
        }

        private void OnPlayerJoined(PlayerInput playerInput)
        {
            int targer = playerInput.devices[0].deviceId;
            int index = PlayerSelectionController.DevicesID.IndexOf(targer);
            
            if (index == 0)
            {
                Debug.Log(" Player One ");
                // ScriptableObjectDansPrefab = PlayerSelectionController.ScriptableobjectPlayerOne;
            }
            if (index == 1)
            {
                Debug.Log(" Player Two ");
                // ScriptableObjectDansPrefab = PlayerSelectionController.ScriptableobjectPlayerOne;
            }
            if (index == 2)
            {
                Debug.Log(" Player Three ");
                // ScriptableObjectDansPrefab = PlayerSelectionController.ScriptableobjectPlayerOne;
            }
            if (index == 3)
            {
                Debug.Log(" Player Four ");
                // ScriptableObjectDansPrefab = PlayerSelectionController.ScriptableobjectPlayerOne;
            }
        }
    }
}
