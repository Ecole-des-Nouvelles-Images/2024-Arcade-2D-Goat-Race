using System;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using Image = UnityEngine.UI.Image;

public class SelectionGoat : MonoBehaviour
{
    public PlayerData CurentSelectedData;

    [SerializeField] private int index;
    [SerializeField] private List<PlayerData> playerData = new List<PlayerData>();
    [SerializeField] private Image _goatImage;
    
    private PlayerInput playerInput;
    private InputSystemUIInputModule uiModule;
    private MultiplayerEventSystem eventSystem;
    

    void Awake()
    {
        if (playerInput == null)
            playerInput = GetComponentInParent<PlayerInput>();

        if (uiModule == null)
            uiModule = GetComponentInChildren<InputSystemUIInputModule>();

        if (eventSystem == null)
            eventSystem = GetComponentInChildren<MultiplayerEventSystem>();

        uiModule.actionsAsset = playerInput.actions;
        eventSystem.playerRoot = gameObject;
        
    }
    
    private void Start()
    {
        _goatImage.sprite = playerData[index].Sprite;
        playerInput.uiInputModule = uiModule;
        GameObject parent = GameObject.Find("SelectionPlayerPanel");
        gameObject.transform.SetParent(parent.transform);
    }

    public void NextGoat()
    {
        index++;
        if (index > playerData.Count - 1) index = 0;
        CurentSelectedData = playerData[index];
        RefreshVisual();
    }
    
    public void PreviouGoat()
    {
        index--;
        if (index < 0) index = playerData.Count - 1;
        CurentSelectedData = playerData[index];
        RefreshVisual();
    }

    private void RefreshVisual()
    {
        _goatImage.sprite = playerData[index].Sprite;
    }
}
