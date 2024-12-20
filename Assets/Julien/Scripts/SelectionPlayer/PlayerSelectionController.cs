using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Julien.Scripts.SelectionPlayer
{
    public class PlayerSelectionController : MonoBehaviour
    {
        public static GoatData ScriptableobjectPlayerOne;
        public static GoatData ScriptableobjectPlayerTwo;
        public static GoatData ScriptableobjectPlayerThree;
        public static GoatData ScriptableobjectPlayerFour;
        public static List<int> DevicesID = new List<int>();
        
        public int _playerNumber;
        
        [SerializeField] private GameObject _curentSelectedButton;
        
        private PlayerInput _playerInput;

        [SerializeField] private EventSystem _eventSystem;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
        }

        private void Start()
        {
            Debug.Log(" Player Index : " + _playerNumber);
            
            DevicesID.Add(_playerInput.devices[0].deviceId);
            Debug.Log(" Device ID : " + _playerInput.devices[0].deviceId);
        }

        private void Update()
        {
            _curentSelectedButton = _eventSystem.currentSelectedGameObject;
            if (_playerInput.actions["UI/Submit"].triggered)
            {
                if (_playerNumber == 1)
                {
                    ScriptableobjectPlayerOne = _curentSelectedButton.GetComponent<ButtonSelectGoat>().GoatData;
                    Debug.Log("Change Player 1 Goat" + ScriptableobjectPlayerOne);
                }
                if (_playerNumber == 2)
                {
                    ScriptableobjectPlayerTwo = _curentSelectedButton.GetComponent<ButtonSelectGoat>().GoatData;
                    Debug.Log("Change Player 2 Goat" + ScriptableobjectPlayerTwo);
                }
                if (_playerNumber == 3)
                {
                    ScriptableobjectPlayerThree = _curentSelectedButton.GetComponent<ButtonSelectGoat>().GoatData;
                    Debug.Log("Change Player 3 Goat" + ScriptableobjectPlayerThree);
                }
                if (_playerNumber == 4)
                {
                    ScriptableobjectPlayerFour = _curentSelectedButton.GetComponent<ButtonSelectGoat>().GoatData;
                    Debug.Log("Change Player 4 Goat" + ScriptableobjectPlayerFour);
                }
            }
        }
    }
}
