using Julien.Scripts.SelectionPlayer;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Julien.Scripts.Player
{
    public class PlayerSpawnHandler : MonoBehaviour
    {
        private PlayerInputManager _playerInputManager;
        [SerializeField] private int _playerNumber;

        public static int NumberPlayerOnMap;
        
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
                playerInput.gameObject.GetComponent<Goat>().PlayerNumber = 1;
                GameManager1.IndexPlayer++;
                
                playerInput.gameObject.name = "PlayerOne";
                NumberPlayerOnMap++;
            }
            if (_playerNumber == 1)
            {
                playerInput.gameObject.GetComponent<Goat>().GoatData = PlayerSelectionController.ScriptableobjectPlayerTwo;
                playerInput.gameObject.GetComponent<Goat>().PlayerNumber = 2;
                GameManager1.IndexPlayer++;
                
                playerInput.gameObject.name = "PlayerTwo";
                NumberPlayerOnMap++;
            }
            if (_playerNumber == 2)
            {
                playerInput.gameObject.GetComponent<Goat>().GoatData = PlayerSelectionController.ScriptableobjectPlayerThree;
                playerInput.gameObject.GetComponent<Goat>().PlayerNumber = 3;
                GameManager1.IndexPlayer++;
                
                playerInput.gameObject.name = "PlayerThree";
                NumberPlayerOnMap++;
            }
            if (_playerNumber == 3)
            {
                playerInput.gameObject.GetComponent<Goat>().GoatData = PlayerSelectionController.ScriptableobjectPlayerFour;
                playerInput.gameObject.GetComponent<Goat>().PlayerNumber = 4;
                GameManager1.IndexPlayer++;
                
                playerInput.gameObject.name = "PlayerFour";
                NumberPlayerOnMap++;
            }
        }
    }
}
