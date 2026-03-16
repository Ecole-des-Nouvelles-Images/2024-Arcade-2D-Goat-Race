using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Datas")]
    public GoatData GoatData;
    private Rigidbody2D rb2d;

    [Header("Move")]
    public bool CanMove;
    public float MoveDirection;
    [SerializeField] private float _speed;

    [Header("Jump")] 
    public bool CanJump;
    [SerializeField] private float _jumpForce;
    
    [Header("Visuel")]
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        if (!CanMove) return;
        Vector2 Velocity = rb2d.velocity;
        Velocity.x = MoveDirection * (_speed + GoatData.Speed);
        
        rb2d.velocity = Velocity;
        
        if (MoveDirection > 0) _spriteRenderer.flipX = true;
        if (MoveDirection < 0) _spriteRenderer.flipX = false;
    }

    public void Jump()
    {
        if (!CanJump) return;
        rb2d.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}
