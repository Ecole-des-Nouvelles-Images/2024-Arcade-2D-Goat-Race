using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Julien.Scripts.SelectionPlayer
{
    public class PlayerInputGoatSelectionHandler : MonoBehaviour
    {
        public static PlayerInputGoatSelectionHandler Instance;
        public int NumberPlayer;
        public int NumberPlayerReady;
        public List<PlayerData> PlayerData = new List<PlayerData>();
        private PlayerInputManager _playerInputManager;

        private void Awake()
        {
            Instance = this;
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
            Debug.Log("PlayerJoinded " +  playerInput.playerIndex);
            NumberPlayer++;
            playerInput.transform.gameObject.GetComponent<SelectionGoat>().IndexPlayer = NumberPlayer;
            PlayerData.Add(null);
        }

        public void PlayerGetReadyOrNotReady(bool ready)
        {
            if (ready) NumberPlayerReady++;
            if (!ready) NumberPlayerReady--;

            if (NumberPlayerReady == NumberPlayer && NumberPlayerReady >= 2)
            {
                PlayerManager.PlayerData = PlayerData;
                SceneManager.LoadScene("RefactoTest");
            }
        }

        public void ChangeDataList(PlayerData playerData, int index)
        {
            PlayerData[index - 1] = playerData;
        }
    }
}
