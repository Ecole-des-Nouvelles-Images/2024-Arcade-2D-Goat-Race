using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace Julien.Scripts
{
    public class Goat : MonoBehaviour
    {
        [FormerlySerializedAs("Goats")] [SerializeField] private List<GoatData> GoatsDatas;
        
        [SerializeField] private Animator _animator;
        [SerializeField] private RuntimeAnimatorController _animatorController;
        
        public bool PlayerOne;
        public GoatData GoatData;
        public Sprite Sprite;
        private SpriteRenderer _spriteRenderer;
    
        private float _sizeX;
        private float _sizeY;
        private BoxCollider2D _boxCollider2D;
        private float _cameraDistance;
        [SerializeField] private Camera _camera;
        private float CameraZ;
        private float CameraY;
        private float CameraX;
    
        // Les déplacement
        private float _airControl = 0.5f; 
        public float Speed; 
        private float _jumpForce = 3f;
        private Vector2 _movementInput;
        private PlayerInputHandler _playerInputHandler;
   
        // Dash
        public bool CanDash = true;
        public bool IsDashing;
        private float _dashDelay = 1.5f;
        private float _dashPower = 1.5f;
        private float _dashReload = 5f;
   
        // Is Jump
        private float _jumpTimeCounter;
        private bool _isJumping;
        private float _maxJumpTime = 0.5f;
        private float _additionalJumpForce = 0.15f;
        
        // Is Grounded
        [SerializeField] private GameObject _ColliderGrounded;
        [SerializeField] private float _colliderIsGroundedPositionY;
        [SerializeField] private float _colliderIsGroundedScaleX;
    
        [SerializeField] private LayerMask _layerMaskGrounded;
        private float _rayDistance = 0.55f;
        public bool CanJump; 
    
        // Atataque
        [SerializeField] private bool _canAttaque;
        [SerializeField] private LayerMask _layerMaskObstacle;
        [SerializeField] private float _rangeAttaque;
        [SerializeField] private int _damage;
        [SerializeField] private float _coulDownAttaque;
        private RaycastHit2D _hitResult;
    
        private Rigidbody2D rb2d;

        private void Start()
        {
            // Debug.Log("Player 1 IN GAME " + GlobalVariable.GoatNamePlayer1);
            // Debug.Log("Player 2 IN GAME " + GlobalVariable.GoatNamePlayer2);

            foreach (GoatData goatData in GoatsDatas)
            {
                if (PlayerOne && GlobalVariable.GoatNamePlayer1 == goatData.name)
                {
                    GoatData = goatData;
                    Debug.Log("Player 1 IN GAME " + goatData.name);
                }
                if (PlayerOne == false && GlobalVariable.GoatNamePlayer2 == goatData.name)
                {
                    GoatData = goatData;
                    Debug.Log("Player 2 IN GAME " + goatData.name);
                }
            }
            
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _playerInputHandler = GetComponent<PlayerInputHandler>();
            rb2d = GetComponent<Rigidbody2D>();
            _animator = gameObject.GetComponent<Animator>();
            _animatorController = _animator.runtimeAnimatorController;
            LoadGoat();
        }

        public void LoadGoat()
        {
            Sprite = GoatData.Sprite;
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            _spriteRenderer.sprite = Sprite;
        
            _damage = GoatData.Damage;
            _rangeAttaque = GoatData.RangeAttaque;
            //Speed = GoatData.Speed;
            _jumpForce = GoatData.JumpForce;
            _rayDistance = GoatData.RayDistance;
            _cameraDistance = GoatData.CameraZ;
        
            _sizeX = GoatData.Collider2DAxeX;
            _sizeY = GoatData.Collider2DAxeY;

            // CAMERA
            CameraZ = GoatData.CameraZ;
            CameraY = GoatData.CameraY;
            CameraX = GoatData.CameraX;
        
            _camera.transform.localPosition = new Vector3(CameraX, CameraY, CameraZ);

            _boxCollider2D.size = new Vector2(_sizeX,_sizeY);

            
            // ANIMATOR
            _animatorController = GoatData.AnimatorController;
            _animator.runtimeAnimatorController = _animatorController;
        
            // COLLISION DU IS GROUNDED
            _colliderIsGroundedPositionY = GoatData.ColliderIsGroundedPositionY;
            _colliderIsGroundedScaleX = GoatData.ColliderIsGroundedScaleX;

            _colliderIsGroundedPositionY = GoatData.ColliderIsGroundedPositionY;
            _colliderIsGroundedScaleX = GoatData.ColliderIsGroundedScaleX;

            _ColliderGrounded.transform.localPosition = new Vector3(0, -_colliderIsGroundedPositionY, 0);
            _ColliderGrounded.transform.localScale = new Vector3(_colliderIsGroundedScaleX, 0.3f, 0);
        }
    
        private void Update()
        {
            // RENDRE LE DEPLACEMENT DE X TOUJOURS A 1 OU -1
            if (IsDashing == false)
            {
                if (_playerInputHandler.Move.x > 0)
                {
                    _playerInputHandler.Move.x = Mathf.Clamp(_playerInputHandler.Move.x, 1, 1);
                }
                else if (_playerInputHandler.Move.x < 0)
                {
                    _playerInputHandler.Move.x = Mathf.Clamp(_playerInputHandler.Move.x, -1, -1);
                }  
            }
            
            if (_playerInputHandler.Move.x < 0 || _playerInputHandler.Move.x > 0)
            {
                _animator.SetTrigger("IsMoving");
                //Debug.Log("IsMoving = True");
                _spriteRenderer.color = Color.yellow;
            }
            else
            {
                _animator.ResetTrigger("IsMoving");
                //Debug.Log("IsMoving = False");
                _spriteRenderer.color = Color.white;
            }
            OnJumpStay();
            
            if (rb2d.velocity.y < -0.5f)
            {
                rb2d.gravityScale = 6f;
            }
            else
            {
                rb2d.gravityScale = 3.5f;
            }
            
            // ANIMATION
            if (_isJumping == false)
            {
                OnJumpStop();
            }

            if (_isJumping)
            {
                OnJumpStay();
            }

            if (CanJump == false)
            {
                _animator.SetTrigger("IsGrounded");
                // Debug.Log("IsGrounded = True");
                //_spriteRenderer.color = Color.blue;
            }
            else
            {
                _animator.ResetTrigger("IsGrounded");
            }
        }

        private void FixedUpdate()
        {
            OnMove();
        }
    
        // SAUT
        public void OnJump()
        {
            bool Release;
            
            if (CanJump && _isJumping == false)
            {
                rb2d.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                _isJumping = true;
                _jumpTimeCounter = 0f;
                Debug.Log("1");
            }
            // else
            // {
            //     Debug.Log("2");
            //     _isJumping = false;
            //     //Debug.Log("IsGrounded = False");
            // }
        }

        public void OnJumpCancel()
        {
            if (CanJump == false && _isJumping)
            {
                _isJumping = false;  
            }
        }
        private void OnJumpStay()
        {
            if (_isJumping)
            {
                _jumpTimeCounter += Time.deltaTime;

                if (_jumpTimeCounter < _maxJumpTime)
                {
                    rb2d.velocity = new Vector2(rb2d.velocity.x, _jumpForce + _additionalJumpForce * _jumpTimeCounter);
                }

                if (_jumpTimeCounter >= _maxJumpTime)
                {
                    OnJumpStop();
                }
            }
            else
            {
                OnJumpStop();
            }
        }

        public void OnJumpStop()
        {
            if (_isJumping)
            {
                _isJumping = false;
            }
        }
        
        // DEPLACEMENT 
        public void OnMove()
        {
            float Horizontal = _playerInputHandler.Move.x;
            Vector2 Velocity = rb2d.velocity;
            Velocity.x = Horizontal * (Speed + GoatData.Speed);
        
            rb2d.velocity = Velocity;
        
            // FLIP LE SPRITE
            if (_playerInputHandler.Move.x > 0)
            {
                _spriteRenderer.flipX = true;
            }
            else if (_playerInputHandler.Move.x < 0)
            {
                _spriteRenderer.flipX = false;
            }
        }
    
        // ATTAQUE
        public void OnAttaque()
        {
            if (_canAttaque)
            {
                // ATTAQUE DROITE
                if (_spriteRenderer.flipX)
                {
                    Debug.DrawRay(transform.position, Vector2.right * _rangeAttaque, Color.blue, 1f);
                    RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.right, _rangeAttaque, _layerMaskObstacle);
                    _hitResult = hit2D;

                    _canAttaque = false;
                    StartCoroutine("RealoadAttaque");
                    
                    
                    // ANIMATION 
                    _animator.ResetTrigger("IsAttack");
                    Debug.Log("IsGrounded = True");
                }
                // ATTAQUE GAUCHE
                else
                {
                    Debug.DrawRay(transform.position, -Vector2.right * _rangeAttaque, Color.blue, 1f);
                    RaycastHit2D hit2D = Physics2D.Raycast(transform.position, -Vector2.right, _rangeAttaque, _layerMaskObstacle);
                    _hitResult = hit2D;
                
                    _canAttaque = false;
                    StartCoroutine("RealoadAttaque");
                    
                    
                    // ANIMATION 
                    _animator.ResetTrigger("IsAttack");
                    Debug.Log("IsGrounded = True");
                }
        
                // JOUER AVEC CE QUE LE RAYCAST A TOUCHER
                if (_hitResult.collider != null)
                {
                    Debug.Log(" à toucher "  +  _hitResult.collider.name);
                    _hitResult.collider.gameObject.GetComponent<Obstacle>().Health -= _damage;
                    if (_hitResult.collider.gameObject.GetComponent<Obstacle>().Health <= 0)
                    {
                        Destroy(_hitResult.collider.gameObject);
                    }
                }
                else
                {
                    Debug.Log(" touche pas ");
                }
        
        
                Debug.Log("Attaque");
            }
        }

        public IEnumerator RealoadAttaque()
        {
            yield return new WaitForSeconds(1f);
            _canAttaque = true;
            Debug.Log("à re son attaque");
        }

        // DASH
        public void OnDash()
        {
            IsDashing = true;
        
            if (_spriteRenderer.flipX)
            {
                _playerInputHandler.Move.x = _dashPower;
                
                // ANIMATION
                _animator.SetTrigger("IsDashing"); 
                Debug.Log("IsDashin = True");   
                _spriteRenderer.color = Color.red;

            }
            else
            {
                _playerInputHandler.Move.x = -_dashPower;
                
                // ANIMATION
                _animator.SetTrigger("IsDashing"); 
                Debug.Log("IsDashin = True");   
                _spriteRenderer.color = Color.red;

            }
            
            CanDash = false;
            StartCoroutine(DashDelaying());
        }
        public IEnumerator DashDelaying()
        {
            yield return new WaitForSeconds(_dashDelay);
            IsDashing = false;
            _playerInputHandler.Move.x = 0;
            yield return new WaitForSeconds(_dashReload);
            CanDash = true;
            Debug.Log("reload dash");
            
            // ANIMATION
            _animator.ResetTrigger("IsDashing");
            Debug.Log("IsDashing = False");
            _spriteRenderer.color = Color.white;
        }
    }
}
