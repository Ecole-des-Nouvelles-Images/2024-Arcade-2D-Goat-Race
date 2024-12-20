using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
        
        private PlayerInput _playerInput;

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
            if (_playerInput.actions["UI/Submit"].triggered)
            {
                if (_playerNumber == 1)
                {
                    // PlayerOne = 
                }
            }
        }
    }
}
