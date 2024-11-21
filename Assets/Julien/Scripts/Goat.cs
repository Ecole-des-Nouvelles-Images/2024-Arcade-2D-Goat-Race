using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class Goat : MonoBehaviour
{
    public GoatData GoatData;
    public Sprite SpriteRenderer;
    private float _sizeX;
    private float _sizeY;
    private BoxCollider2D _boxCollider2D;
    private float _cameraDistance;
    [SerializeField] private Camera _camera;
    [SerializeField] private float FOV;
    
    // Les déplacement
    [SerializeField] private float _airControl = 0.5f; 
    [SerializeField] private float _speed =5f;
    [SerializeField] private float _jumpForce = 3f;
    private Vector2 _movementInput;
    private PlayerInputHandler _playerInputHandler;
   
   // Dash
   public bool CanDash = true;
   public bool IsDashing;
   [SerializeField] private float DashDelay = 1.5f;
   [SerializeField] private float DashPower = 1.5f;
   [SerializeField] private float DashReload = 5f;
   
    // Is Grounded
    [SerializeField] private LayerMask _layerMaskGrounded;
    private float _rayDistance = 0.55f;
    private bool CanJump; 
    
    // Atataque
    [SerializeField] private LayerMask _layerMaskObstacle;
    [SerializeField] private float _rangeAttaque;
    [SerializeField] private int _damage;
    [SerializeField] private float _coulDownAttaque;
    private RaycastHit2D _hitResult;
    
    private Rigidbody2D rb2d;

    private void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _playerInputHandler = GetComponent<PlayerInputHandler>();
        rb2d = GetComponent<Rigidbody2D>();
        LoadGoat();
    }

    private void LoadGoat()
    {
        SpriteRenderer = GoatData.Sprite;
        gameObject.GetComponent<SpriteRenderer>().sprite = SpriteRenderer;
        
        _damage = GoatData.Damage;
        _rangeAttaque = GoatData.RangeAttaque;
        _speed = GoatData.Speed;
        _jumpForce = GoatData.JumpForce;
        _rayDistance = GoatData.RayDistance;
        _cameraDistance = GoatData.CameraFOV;
        
        _sizeX = GoatData.Collider2DAxeX;
        _sizeY = GoatData.Collider2DAxeY;

        FOV = GoatData.CameraFOV;
        _camera.fieldOfView = FOV;

        _boxCollider2D.size = new Vector2(_sizeX,_sizeY);
    }
    
    private void Update()
    {
        // Jump HitGround
        Debug.DrawRay(transform.position, Vector3.down * _rayDistance, Color.red);
        RaycastHit2D HitGround = Physics2D.Raycast(transform.position, -Vector2.up, _rayDistance, _layerMaskGrounded);
        CanJump = HitGround.collider;
    }

    private void FixedUpdate()
    {
        // DEPLACEMENT
        float Horizontal = _playerInputHandler.Move.x;
        Vector2 Velocity = rb2d.velocity;
        Velocity.x = Horizontal * _speed;
        
        rb2d.velocity = Velocity;
    }
    
    
    // MOUVEMENT
    public void OnMove(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
        
        float horizontal = _movementInput.x * Time.deltaTime * _speed;
        Vector2 direction = new Vector2(horizontal, 0).normalized;
        rb2d.AddForce(direction * _speed);
    }
    public void OnJump()
    {
        if (CanJump)
        {
            rb2d.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            Debug.Log("Jump");
        }
    }

    // ATTAQUE
    public void OnAttaque()
    {
        if (_playerInputHandler.Move.x >= 0)
        {
            Debug.DrawRay(transform.position, Vector2.right, Color.blue, _rangeAttaque);
            RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.right, _rangeAttaque, _layerMaskObstacle);
            _hitResult = hit2D;
        }
        else
        {
            Debug.DrawRay(transform.position, -Vector2.right, Color.blue, _rangeAttaque);
            RaycastHit2D hit2D = Physics2D.Raycast(transform.position, -Vector2.right, _rangeAttaque, _layerMaskObstacle);
            _hitResult = hit2D;
        }
        

        if (_hitResult.collider != null)
        {
            Debug.Log(" à toucher "  +  _hitResult.collider.name);
            
        }
        else
        {
            Debug.Log(" touche pas ");
        }
        
        
        Debug.Log("Attaque");
    }

    // DASH
    public void OnDash()
    {
        IsDashing = true;
        
        if (_playerInputHandler.Move.x >= 0 && CanDash)
        {
            _playerInputHandler.Move.x = DashPower;
        }
        else
        {
            _playerInputHandler.Move.x = -DashPower;
        }
        
        CanDash = false;
        StartCoroutine(DashDelaying());
    }
    public IEnumerator DashDelaying()
    {
        yield return new WaitForSeconds(DashDelay);
        IsDashing = false;
        _playerInputHandler.Move.x = 0;
        yield return new WaitForSeconds(DashReload);
        CanDash = true;
        Debug.Log("reload dash");
    }
}
