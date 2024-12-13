using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Julien.Scripts
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        public static event Action<bool> OnInputDeviceChanged;
        [SerializeField] private GameManager GameManager;
        [SerializeField] private PlayerInputManager PlayerInputManager;
    
        public Vector2 Move;
    
        private Rigidbody2D rb2d;
        private Goat _goat;
        private InventaryBonus _inventaryBonus;
        private PlayerInput _playerInput;
        private bool _isControllerConnected;

        [SerializeField] private UI_MenuManager _uiMenuManager;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            rb2d = GetComponent<Rigidbody2D>();
            _goat = GetComponent<Goat>();
            _inventaryBonus = GetComponent<InventaryBonus>();
            _playerInput = GetComponent<PlayerInput>();
            if (_playerInput == null) throw new NullReferenceException("PlayerInputManager is null");
        }
        

        private void OnEnable()
        {
            InputSystem.onDeviceChange += OnDeviceChange;

            // Bind input actions
            _playerInput.actions["Movement"].performed += OnMove;
            _playerInput.actions["Movement"].canceled += OnMove;
            
            _playerInput.actions["Pause"].performed += Pause;
            _playerInput.actions["Pause"].canceled += Pause;
        
            _playerInput.actions["Dash"].performed += OnDash;
        
            _playerInput.actions["Attaque"].performed += OnAttaque;
            _playerInput.actions["Attaque"].canceled += OnAttaque;
        
            _playerInput.actions["Jump"].started += OnJump;
            _playerInput.actions["Jump"].canceled += OnJumpCancel;
            // _playerInput.actions["Jump"].performed += OnJumpStay;
            // _playerInput.actions["Jump"].canceled += OnJumpStop;
            
            _playerInput.actions["UseBonus"].performed += OnUseBonus;
        
            DetectCurrentInputDevice();
            //GameManager.AddTolist(PlayerInputManager.playerPrefab);
        
            // GameManager.PlayerPrefabs.Add(PlayerInputManager.playerPrefab.gameObject);
            // Debug.Log(PlayerInputManager.playerPrefab.gameObject+ " Join the game " );
        }
        
        private void OnDisable()
        {
            InputSystem.onDeviceChange -= OnDeviceChange;

            // Unbind input actions
            _playerInput.actions["Movement"].performed -= OnMove;
            _playerInput.actions["Movement"].canceled -= OnMove;
            
            _playerInput.actions["Pause"].performed -= Pause;
            _playerInput.actions["Pause"].canceled -= Pause;
        
            _playerInput.actions["Dash"].performed -= OnDash;
            _playerInput.actions["Dash"].canceled -= OnDash;
        
            _playerInput.actions["Dash"].performed -= OnAttaque;
            _playerInput.actions["Dash"].canceled -= OnAttaque;
        
            _playerInput.actions["Jump"].performed -= OnJump;
            // _playerInput.actions["Jump"].performed -= OnJumpStay;
            // _playerInput.actions["Jump"].canceled -= OnJumpStop;
            
            _playerInput.actions["UseBonus"].performed -= OnUseBonus;
            _playerInput.actions["UseBonus"].canceled -= OnUseBonus;
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
    
        private void OnMove(InputAction.CallbackContext context)
        {
            if (_goat.IsDashing == false)
            {
                Move = context.ReadValue<Vector2>();
            }
        }

        
        private void OnJump(InputAction.CallbackContext context)
        {
            _goat.OnJump();
        }

        public void OnJumpCancel(InputAction.CallbackContext context)
        {
            _goat.OnJumpStop();
        }
        
        
        private void OnDash(InputAction.CallbackContext context)
        {
            _goat.OnDash(); 
        }

        private void OnAttaque(InputAction.CallbackContext context)
        {
            _goat.OnAttaque(context.ReadValue<float>());
        }

        private void OnUseBonus(InputAction.CallbackContext context)
        {
            if (_inventaryBonus.HaveBonus && _inventaryBonus.IsUsingBonus == false)
            {
                _inventaryBonus.Use();
                _inventaryBonus.HaveBonus = false;
            }
            else
            {
                
            }
        }

        private void Pause(InputAction.CallbackContext context)
        {
            _uiMenuManager.OpenPauseMenu();
        }
    }
}
