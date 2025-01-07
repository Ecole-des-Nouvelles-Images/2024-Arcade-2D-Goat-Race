using System;
using Cinemachine;
using Julien.Scripts.Player;
using Julien.Scripts.SelectionPlayer;
using UnityEngine;
using UnityEngine.InputSystem;

public class SetUpCamera : MonoBehaviour
{
    [SerializeField] private GameObject _player1CameraGameObject;
    [SerializeField] private GameObject _player2CameraGameObject;
    [SerializeField] private GameObject _player3CameraGameObject;
    [SerializeField] private GameObject _player4CameraGameObject;

    [Header("<color=green> CineMachineCamera </color>")]
    
    [SerializeField] private GameObject _cineMachineP1;
    [SerializeField] private GameObject _cineMachineP2;
    [SerializeField] private GameObject _cineMachineP3;
    [SerializeField] private GameObject _cineMachineP4;

    [Header("<color=red> LayoutHUD </color>")]
    
    [SerializeField] private GameObject _layoutOnePlayer;
    [SerializeField] private GameObject _layoutTwoPlayer;
    [SerializeField] private GameObject _layoutThreePlayer;
    [SerializeField] private GameObject _layoutFourPlayer;
    
    private Camera _player1Camera;
    private Camera _player2Camera;
    private Camera _player3Camera;
    private Camera _player4Camera;
    private PlayerInputManager _playerInputManager;
    

    private void Awake()
    {
        
    }

    private void Start()
    {
        _playerInputManager = GetComponent<PlayerInputManager>();
        _player1Camera = _player1CameraGameObject.GetComponent<Camera>();
        _player2Camera = _player2CameraGameObject.GetComponent<Camera>();
        _player3Camera = _player3CameraGameObject.GetComponent<Camera>();
        _player4Camera = _player4CameraGameObject.GetComponent<Camera>();
    }

    private void Update()
    {
        if (PlayerSpawnHandler.NumberPlayerOnMap == PlayerSelectionController.NumberOfPlayer)
        {
            SetUp();
        }
    }
    
    private void SetUp()
    {
        if (PlayerSelectionController.NumberOfPlayer == 1)
        {
            _player1CameraGameObject.SetActive(true);
            
            _player1Camera.rect = new Rect(0, 0, 1, 1);

            _cineMachineP1.SetActive(true);
            
            _cineMachineP1.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.Find("PlayerOne").gameObject.transform;
            
            _layoutOnePlayer.SetActive(true);
            _layoutTwoPlayer.SetActive(false);
            _layoutThreePlayer.SetActive(false);
            _layoutFourPlayer.SetActive(false);
        }
        if (PlayerSelectionController.NumberOfPlayer == 2)
        {
            _player1CameraGameObject.SetActive(true);
            _player2CameraGameObject.SetActive(true);
            
            _player1Camera.rect = new Rect(0, 0.5f, 1, 0.5f);
            _player2Camera.rect = new Rect(0, 0, 1, 0.5f);
            
            _cineMachineP1.SetActive(true);
            _cineMachineP2.SetActive(true);
            
            _cineMachineP1.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.Find("PlayerOne").gameObject.transform;
            _cineMachineP2.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.Find("PlayerTwo").gameObject.transform;
            
            _layoutOnePlayer.SetActive(false);
            _layoutTwoPlayer.SetActive(true);
            _layoutThreePlayer.SetActive(false);
            _layoutFourPlayer.SetActive(false);
        }
        
        if (PlayerSelectionController.NumberOfPlayer == 3)
        {
            _player1CameraGameObject.SetActive(true);
            _player2CameraGameObject.SetActive(true);
            _player3CameraGameObject.SetActive(true);
            
            _player1Camera.rect = new Rect(0, 0.5f, 1, 0.5f);
            _player2Camera.rect = new Rect(0, 0, 0.5f, 0.5f);
            _player3Camera.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
            
            _cineMachineP1.SetActive(true);
            _cineMachineP2.SetActive(true);
            _cineMachineP3.SetActive(true);
            
            _cineMachineP1.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.Find("PlayerOne").gameObject.transform;
            _cineMachineP2.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.Find("PlayerTwo").gameObject.transform;
            _cineMachineP3.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.Find("PlayerThree").gameObject.transform;
            
            _layoutOnePlayer.SetActive(false);
            _layoutTwoPlayer.SetActive(false);
            _layoutThreePlayer.SetActive(true);
            _layoutFourPlayer.SetActive(false);
        }
        if (PlayerSelectionController.NumberOfPlayer == 4)
        {
            _player1CameraGameObject.SetActive(true);
            _player2CameraGameObject.SetActive(true);
            _player3CameraGameObject.SetActive(true);
            _player4CameraGameObject.SetActive(true);
            
            _player1Camera.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
            _player2Camera.rect = new Rect(0.5f, 0.5f, 1, 1);
            _player3Camera.rect = new Rect(0, 0, 0.5f, 0.5f);
            _player4Camera.rect = new Rect(0.5f, 0, 1, 0.5f);
            
            _cineMachineP1.SetActive(true);
            _cineMachineP2.SetActive(true);
            _cineMachineP3.SetActive(true);
            _cineMachineP4.SetActive(true);
            
            _cineMachineP1.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.Find("PlayerOne").gameObject.transform;
            _cineMachineP2.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.Find("PlayerTwo").gameObject.transform;
            _cineMachineP3.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.Find("PlayerThree").gameObject.transform;
            _cineMachineP4.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.Find("PlayerFour").gameObject.transform;
            
            _layoutOnePlayer.SetActive(false);
            _layoutTwoPlayer.SetActive(false);
            _layoutThreePlayer.SetActive(false);
            _layoutFourPlayer.SetActive(true);
        }
    }
}
