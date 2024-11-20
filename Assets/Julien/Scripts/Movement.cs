using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    // Les déplacement
    [SerializeField] private float _airControl = 0.5f; 
    public float Speed =5f;
    public float JumpForce = 3f;
    private Vector2 _movementInput;
    private PlayerInputHandler _playerInputHandler;
   
   // Dash
   public bool CanDash = true;
   public bool IsDashing;
   [SerializeField] private float DashDelay = 1.5f;
   [SerializeField] private float DashPower = 1.5f;
   [SerializeField] private float DashReload = 5f;
   
    // Is Grounded
    [SerializeField] private LayerMask _layerMask;
    private float _rayDistance = 0.55f;
    private bool CanJump; 
    
    private Rigidbody2D rb2d;
    
    private void Awake()
    {
        _playerInputHandler = GetComponent<PlayerInputHandler>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Jump HitGround
        Debug.DrawRay(transform.position, Vector3.down * _rayDistance, Color.red);
        RaycastHit2D HitGround = Physics2D.Raycast(transform.position, -Vector2.up, _rayDistance, _layerMask);
        CanJump = HitGround.collider;


        if (IsDashing)
        {
            Color playerColor = gameObject.GetComponent<SpriteRenderer>().color;
            playerColor.r = 255f;
        }
    }

    private void FixedUpdate()
    {
        float Horizontal = _playerInputHandler.Move.x;
        Vector2 Velocity = rb2d.velocity;
        Velocity.x = Horizontal * Speed;
        
        rb2d.velocity = Velocity;
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
        
        float horizontal = _movementInput.x * Time.deltaTime * Speed;
        Vector2 direction = new Vector2(horizontal, 0).normalized;
        rb2d.AddForce(direction * Speed);
    }
    public void OnJump()
    {
        if (CanJump)
        {
            rb2d.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }

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
