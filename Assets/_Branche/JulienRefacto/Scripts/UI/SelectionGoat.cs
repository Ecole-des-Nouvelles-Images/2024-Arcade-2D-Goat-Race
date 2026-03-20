using System;
using System.Collections.Generic;
using Julien.Scripts.SelectionPlayer;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using Image = UnityEngine.UI.Image;

public class SelectionGoat : MonoBehaviour
{
    public bool Ready;
    public int IndexPlayer;
    public PlayerData CurentSelectedData;

    [SerializeField] private int index;
    [SerializeField] private List<PlayerData> playerData = new List<PlayerData>();
    [SerializeField] private Image _goatImage;
    [SerializeField] private GameObject _readyPanel;
    
    private PlayerInput _playerInput;
    private InputSystemUIInputModule _uiModule;
    private MultiplayerEventSystem _eventSystem;

    private void OnEnable()
    {
        _playerInput.actions["Cancel"].performed += StopReady;
    }
    
    void Awake()
    {
        if (_playerInput == null)
            _playerInput = GetComponentInParent<PlayerInput>();

        if (_uiModule == null)
            _uiModule = GetComponentInChildren<InputSystemUIInputModule>();

        if (_eventSystem == null)
            _eventSystem = GetComponentInChildren<MultiplayerEventSystem>();

        _uiModule.actionsAsset = _playerInput.actions;
        _eventSystem.playerRoot = gameObject;
        
    }
    
    private void Start()
    {
        _goatImage.sprite = playerData[index].Sprite;
        _playerInput.uiInputModule = _uiModule;
        GameObject parent = GameObject.Find("SelectionPlayerPanel");
        gameObject.transform.SetParent(parent.transform);
        IndexPlayer = PlayerInputGoatSelectionHandler.Instance.NumberPlayer;
        PlayerInputGoatSelectionHandler.Instance.ChangeDataList(CurentSelectedData, IndexPlayer);
    }

    public void NextGoat()
    {
        index++;
        if (index > playerData.Count - 1) index = 0;
        CurentSelectedData = playerData[index];
        PlayerInputGoatSelectionHandler.Instance.ChangeDataList(CurentSelectedData, IndexPlayer);
        RefreshVisual();
    }
    
    public void PreviouGoat()
    {
        index--;
        if (index < 0) index = playerData.Count - 1;
        CurentSelectedData = playerData[index];
        PlayerInputGoatSelectionHandler.Instance.ChangeDataList(CurentSelectedData, IndexPlayer);
        RefreshVisual();
    }

    public void GetReady()
    {
        Debug.Log(" Get ready ");
        _readyPanel.SetActive(true);
        if (!Ready)PlayerInputGoatSelectionHandler.Instance.PlayerGetReadyOrNotReady(true);
        Ready = true;
    }

    private void StopReady(InputAction.CallbackContext obj)
    {
        Debug.Log(" Stop ready ");
        _readyPanel.SetActive(false);
        if (Ready)PlayerInputGoatSelectionHandler.Instance.PlayerGetReadyOrNotReady(false);
        Ready = false;
    }

    private void RefreshVisual()
    {
        _goatImage.sprite = playerData[index].Sprite;
    }
}
