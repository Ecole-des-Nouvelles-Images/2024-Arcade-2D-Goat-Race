using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public static event Action<bool> OnInputDeviceChanged;
    
    public Vector2 Move;
    
    private Rigidbody2D rb2d;
    private Movement movement;
    private PlayerInput _playerInput;
    private bool _isControllerConnected;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movement = GetComponent<Movement>();
        _playerInput = GetComponent<PlayerInput>();
        if (_playerInput == null) throw new NullReferenceException("PlayerInputManager is null");
    }

    private void OnEnable()
    {
        InputSystem.onDeviceChange += OnDeviceChange;

        // Bind input actions
        _playerInput.actions["Movement"].performed += OnMove;
        _playerInput.actions["Movement"].canceled += OnMove;
        
        _playerInput.actions["Dash"].performed += OnDash;
        _playerInput.actions["Dash"].canceled += OnDash;
        
        _playerInput.actions["Jump"].performed += OnJump;
        _playerInput.actions["Jump"].canceled += OnJump;
        
        DetectCurrentInputDevice();
    }
    
    private void OnDisable()
    {
        InputSystem.onDeviceChange -= OnDeviceChange;

        // Unbind input actions
        _playerInput.actions["Movement"].performed -= OnMove;
        _playerInput.actions["Movement"].canceled -= OnMove;
        
        _playerInput.actions["Dash"].performed -= OnDash;
        _playerInput.actions["Dash"].canceled -= OnDash;
        
        _playerInput.actions["Jump"].performed -= OnJump;
        _playerInput.actions["Jump"].canceled -= OnJump;
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

        Debug.Log(_isControllerConnected
            ? "Controller connected: Switching to Gamepad controls."
            : "No controller connected: Switching to Keyboard/Mouse controls.");
    }
    
    private void OnMove(InputAction.CallbackContext context)
    {
        if (movement.IsDashing == false)
        {
            Move = context.ReadValue<Vector2>();  
        }
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (movement.IsDashing == false)
        {
            movement.OnJump(); 
        }
    }

    private void OnDash(InputAction.CallbackContext context)
    {
        if (movement.IsDashing == false && movement.CanDash)
        {
            movement.OnDash(); 
        }
    }
}
