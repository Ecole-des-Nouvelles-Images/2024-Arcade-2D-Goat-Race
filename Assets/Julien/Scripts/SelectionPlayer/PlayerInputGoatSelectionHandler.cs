using UnityEngine;
using UnityEngine.InputSystem;

namespace Julien.Scripts.SelectionPlayer
{
    public class PlayerInputGoatSelectionHandler : MonoBehaviour
    {
        private PlayerInputManager _playerInputManager;

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
            if (playerInput.playerIndex == 0)
            {
                playerInput.gameObject.GetComponent<PlayerSelectionController>()._playerNumber = playerInput.playerIndex + 1;
            }
            if (playerInput.playerIndex == 1)
            {
                playerInput.gameObject.GetComponent<PlayerSelectionController>()._playerNumber = playerInput.playerIndex + 1;
            }
            if (playerInput.playerIndex == 2)
            {
                playerInput.gameObject.GetComponent<PlayerSelectionController>()._playerNumber = playerInput.playerIndex + 1;
            }
            if (playerInput.playerIndex == 3)
            {
                playerInput.gameObject.GetComponent<PlayerSelectionController>()._playerNumber = playerInput.playerIndex + 1;
            }
        }
    }
}
