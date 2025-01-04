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
                playerInput.gameObject.GetComponent<Goat>().PlayerNummber = 1;
                playerInput.gameObject.name = "PlayerOne";
                NumberPlayerOnMap++;
                Debug.Log(" Player One " + PlayerSelectionController.ScriptableobjectPlayerOne);
            }
            if (_playerNumber == 1)
            {
                playerInput.gameObject.GetComponent<Goat>().GoatData = PlayerSelectionController.ScriptableobjectPlayerTwo;
                playerInput.gameObject.GetComponent<Goat>().PlayerNummber = 2;
                playerInput.gameObject.name = "PlayerTwo";
                NumberPlayerOnMap++;
                Debug.Log(" Player Two " + PlayerSelectionController.ScriptableobjectPlayerTwo);
            }
            if (_playerNumber == 3)
            {
                playerInput.gameObject.GetComponent<Goat>().GoatData = PlayerSelectionController.ScriptableobjectPlayerThree;
                playerInput.gameObject.GetComponent<Goat>().PlayerNummber = 3;
                playerInput.gameObject.name = "PlayerThree";
                NumberPlayerOnMap++;
                Debug.Log(" Player Three ");
            }
            if (_playerNumber == 4)
            {
                playerInput.gameObject.GetComponent<Goat>().GoatData = PlayerSelectionController.ScriptableobjectPlayerFour;
                playerInput.gameObject.GetComponent<Goat>().PlayerNummber = 4;
                playerInput.gameObject.name = "PlayerFour";
                NumberPlayerOnMap++;
                Debug.Log(" Player Four ");
            }
            Debug.Log("Joined");
        }
    }
}
