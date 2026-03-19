using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Datas")]
    public PlayerData PlayerData;
    private Rigidbody2D rb2d;

    [Header("Move")]
    public bool CanMove;
    public float MoveDirection;
    [SerializeField] private float _speed;

    [Header("Dash")]
    public bool CanDash;
    [SerializeField] private float _dashCoolDown;
    public float MaxDashTime;
    public float DashCurrentTime;
    public float DashSpeedMultiply;
    [SerializeField] private bool _isDashing;
    [SerializeField] private GameObject CollideLeft;
    [SerializeField] private GameObject CollideRight;
    
    [Header("Jump")] 
    public bool CanJump;
    [SerializeField] private float _jumpForce;

    [Header("Attack")] 
    [SerializeField] private float _damage;
    [SerializeField] private bool _canAttack;
    [SerializeField] private float _attackCoolDown;
    [SerializeField] private LayerMask _layerMask;
    
    [Header("Stun")]
    [SerializeField] private bool _isStun;
    [SerializeField] private float _stunTime;
    
    [Header("Visuel")]
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [Header("Private")] 
    [SerializeField] private PlayerInputHandler _playerInputHandler;

    [Header("Power")]
    public Power EquipedPower;
    
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _playerInputHandler = GetComponent<PlayerInputHandler>();
    }
    
    private void Start()
    {
        SetUpData();
        
        DashCurrentTime  = MaxDashTime;
    }

    public void SetUpData()
    {
        _speed = PlayerData.Speed;
        _damage = PlayerData.Damage;
        
        GameObject visual = Instantiate(PlayerData.VisuelPrefab, transform.position, Quaternion.identity, transform);
        _spriteRenderer = visual.GetComponent<SpriteRenderer>();
        VisualPrefab visualPrefab = visual.GetComponent<VisualPrefab>();
        CollideLeft = visualPrefab.LeftCollider;
        CollideRight = visualPrefab.RightCollider;
        visualPrefab.GroundChecker.GetComponent<GroundChecker>().Player = this;
       
    }

    private void Update()
    {
        if (_isDashing)
        {
            Dash();
            return;
        }
        Move();
    }

    public void Move()
    {
        if (!CanMove) return;
        Vector2 Velocity = rb2d.velocity;
        Velocity.x = MoveDirection * (_speed);
        
        rb2d.velocity = Velocity;
        
        if (MoveDirection > 0) _spriteRenderer.flipX = true;
        if (MoveDirection < 0) _spriteRenderer.flipX = false;
    }

    public void Dash()
    {
        float direction = _spriteRenderer.flipX ? 1f : -1f;
        Vector2 Velocity = rb2d.velocity;
        Velocity.x = direction * (_speed * DashSpeedMultiply);
        rb2d.velocity = Velocity;

        (_spriteRenderer.flipX ? CollideRight : CollideLeft).SetActive(true);
        _isDashing = true;
        DashCurrentTime -= Time.deltaTime;
        CanDash = false;
        if (DashCurrentTime <= 0)
        {
            _isDashing = false;
            DashCurrentTime = MaxDashTime;
            CollideRight.SetActive(false);
            CollideLeft.SetActive(false);
            StartCoroutine("DashCoolDown");
        }
    }

    private IEnumerator DashCoolDown()
    {
        yield return new WaitForSeconds(_dashCoolDown);
        CanDash = true;
    }

    public void Jump()
    {
        if (!CanJump) return;
        rb2d.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    // Attack section
    public void Attack()
    {
        if (MoveDirection != 0 || !_canAttack) return;
        _canAttack = false;
        StartCoroutine("AttackCoolDown");
        float distance = 0;
        if (_spriteRenderer.flipX) distance = 5f;
        if (!_spriteRenderer.flipX) distance = -5f;
        
        Debug.DrawRay(transform.position, Vector2.right * distance, Color.blue, 1f);
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.right,distance, _layerMask);
        if (hit2D) 
        {
            if (hit2D.collider.gameObject.GetComponent<IObstacle>() == null) return;
            hit2D.collider.gameObject.GetComponent<IObstacle>().TakeDamage(_damage); 
        }
    }
    public IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(_attackCoolDown);
        _canAttack = true;
    }

    [ContextMenu("Stun")]
    public void Stun()
    {
        _isStun = true;
        _playerInputHandler.enabled = false;
        rb2d.AddForce(Vector2.up * 15, ForceMode2D.Impulse);
        StartCoroutine("StopStun");
    }

    public IEnumerator StopStun()
    {
        yield return new WaitForSeconds(_stunTime);
        _playerInputHandler.enabled = true;
        _isStun = false;
    }

    public void UseBonus()
    {
        EquipedPower.Use(this);
    }
}
