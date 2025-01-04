using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using UnityEngine.Serialization;

namespace Julien.Scripts.SelectionPlayer
{
    public class PlayerSelectionController : MonoBehaviour
    {
        public static GoatData ScriptableobjectPlayerOne;
        public static GoatData ScriptableobjectPlayerTwo;
        public static GoatData ScriptableobjectPlayerThree;
        public static GoatData ScriptableobjectPlayerFour;

        public static int NumberOfPlayer;
        public static int NumberOfPlayerSelected;
        
        public static List<int> DevicesID = new List<int>();

        [SerializeField] private GameObject _layout1;
        [SerializeField] private GameObject _layout2;
        [SerializeField] private GameObject _layout3;
        [SerializeField] private GameObject _layout4;

        [SerializeField] private GameObject FirtsSelected1;
        [SerializeField] private GameObject FirtsSelected2;
        [SerializeField] private GameObject FirtsSelected3;
        [SerializeField] private GameObject FirtsSelected4;

        private bool _hasSelectedP1;
        private bool _hasSelectedP2;
        private bool _hasSelectedP3;
        private bool _hasSelectedP4;

        [SerializeField] private RectTransform _button1;
        
        // [SerializeField] private GameObject _button1;
        // [SerializeField] private GameObject _button2;
        // [SerializeField] private GameObject _button3;
        // [SerializeField] private GameObject _button4;
        
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

            if (_playerNumber == 1)
            {
                _layout1.SetActive(true);
                _eventSystem.firstSelectedGameObject = FirtsSelected1;
                NumberOfPlayer++;
            }
            if (_playerNumber == 2)
            {
                _layout2.SetActive(true);
                _eventSystem.firstSelectedGameObject = FirtsSelected2;
                NumberOfPlayer++;
            }
            if (_playerNumber == 3)
            {
                _layout3.SetActive(true);
                _eventSystem.firstSelectedGameObject = FirtsSelected3;
                NumberOfPlayer++;
            }
            if (_playerNumber == 4)
            {
                _layout4.SetActive(true);
                _eventSystem.firstSelectedGameObject = FirtsSelected4;
                NumberOfPlayer++;
            }
        }

        private void Update()
        {
            Debug.Log(NumberOfPlayer);
            Debug.Log(NumberOfPlayerSelected);
            _curentSelectedButton = _eventSystem.currentSelectedGameObject;
            if (_playerInput.actions["UI/Submit"].triggered)
            {
                if (_curentSelectedButton.gameObject.GetComponent<ButtonSelectGoat>() == null)
                {
                    
                }
                else
                {
                    if (_playerNumber == 1)
                    {
                        if (_hasSelectedP1)
                        {
                            ScriptableobjectPlayerOne = _curentSelectedButton.GetComponent<ButtonSelectGoat>().GoatData;
                            Debug.Log("Change Player 1 Goat" + ScriptableobjectPlayerOne);
                        }
                        else
                        {
                            ScriptableobjectPlayerOne = _curentSelectedButton.GetComponent<ButtonSelectGoat>().GoatData;
                            Debug.Log("Change Player 1 Goat" + ScriptableobjectPlayerOne);

                            NumberOfPlayerSelected++;
                            _hasSelectedP1 = true;
                        }
                        
                    }
                    if (_playerNumber == 2)
                    {
                        if (_hasSelectedP2)
                        {
                            ScriptableobjectPlayerTwo = _curentSelectedButton.GetComponent<ButtonSelectGoat>().GoatData;
                            Debug.Log("Change Player 2 Goat" + ScriptableobjectPlayerTwo);
                        }
                        else
                        {
                            ScriptableobjectPlayerTwo = _curentSelectedButton.GetComponent<ButtonSelectGoat>().GoatData;
                            Debug.Log("Change Player 2 Goat" + ScriptableobjectPlayerTwo);
                            
                            NumberOfPlayerSelected++;
                            _hasSelectedP2 = true; 
                        }
                        
                        
                    }
                    if (_playerNumber == 3)
                    {
                        if (_hasSelectedP3)
                        {
                            ScriptableobjectPlayerThree = _curentSelectedButton.GetComponent<ButtonSelectGoat>().GoatData;
                            Debug.Log("Change Player 3 Goat" + ScriptableobjectPlayerThree);
                        }
                        else
                        {
                            ScriptableobjectPlayerThree = _curentSelectedButton.GetComponent<ButtonSelectGoat>().GoatData;
                            Debug.Log("Change Player 3 Goat" + ScriptableobjectPlayerThree);
                            
                            NumberOfPlayerSelected++;
                            _hasSelectedP3 = true; 
                        }
                        
                        
                    }
                    if (_playerNumber == 4)
                    {
                        if (_hasSelectedP4)
                        {
                            ScriptableobjectPlayerFour = _curentSelectedButton.GetComponent<ButtonSelectGoat>().GoatData;
                            Debug.Log("Change Player 4 Goat" + ScriptableobjectPlayerFour);
                        }
                        else
                        {
                            ScriptableobjectPlayerFour = _curentSelectedButton.GetComponent<ButtonSelectGoat>().GoatData;
                            Debug.Log("Change Player 4 Goat" + ScriptableobjectPlayerFour);
                            
                            NumberOfPlayerSelected++;
                            _hasSelectedP4 = true; 
                        }
                    }
                }
            }
        }
    }
}
