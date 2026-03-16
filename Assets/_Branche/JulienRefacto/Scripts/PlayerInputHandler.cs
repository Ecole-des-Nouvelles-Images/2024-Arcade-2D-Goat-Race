using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    
    public static event Action<bool> OnInputDeviceChanged;
    private bool _isControllerConnected;
    private PlayerInput _playerInput;
    
    private void Awake()
    {
        _player = GetComponent<Player>();
        _playerInput = GetComponent<PlayerInput>();
        
        if (_playerInput == null) throw new NullReferenceException("PlayerInputManager is null");
    }

    private void OnEnable()
    {
        InputSystem.onDeviceChange += OnDeviceChange;
        DetectCurrentInputDevice();
        
        _playerInput.actions["Movement"].performed += OnMove;
        _playerInput.actions["Movement"].canceled += OnMove;
        
        _playerInput.actions["Jump"].started += OnJump;
        _playerInput.actions["Jump"].canceled += OnJumpCancel;
    }

    private void OnDisable()
    {
        InputSystem.onDeviceChange -= OnDeviceChange;
        
        _playerInput.actions["Movement"].performed -= OnMove;
        _playerInput.actions["Movement"].canceled -= OnMove;
        
        _playerInput.actions["Jump"].started -= OnJump;
        _playerInput.actions["Jump"].canceled -= OnJumpCancel;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _player.MoveDirection = context.ReadValue<Vector2>().x;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        _player.Jump();
    }
    private void OnJumpCancel(InputAction.CallbackContext obj)
    {
        
    }

    
    
    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        if (change == InputDeviceChange.Added || change == InputDeviceChange.Removed)
        {
            DetectCurrentInputDevice();
        }
    }

    private void DetectCurrentInputDevice()
    {
        _isControllerConnected = Gamepad.all.Count > 0;
        OnInputDeviceChanged?.Invoke(_isControllerConnected);

        //Debug.Log(_isControllerConnected
        //? "Controller connected: Switching to Gamepad controls."
        //: "No controller connected: Switching to Keyboard/Mouse controls.");
    }
}
