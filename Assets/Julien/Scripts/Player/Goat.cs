using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace Julien.Scripts
{
    public class Goat : MonoBehaviour
    {
        [SerializeField] private List<GoatData> GoatsDatas;
        
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
        private float _dashDelay = 1.2f;
        private float _dashPower = 1.5f;
        private float _dashReload = 5f;
        [SerializeField] private float _rangeDashAttaque = 1f;
        [SerializeField] private GameObject _dashAttackColliderLeft;
        [SerializeField] private GameObject _dashAttackColliderRight;
   
        // Is Jump
        private float _jumpTimeCounter;
        private bool _isJumping;
        private float _maxJumpTime = 0.5f;
        private float _additionalJumpForce = 0.15f;
        
        // Is Grounded
        [SerializeField] private GameObject _ColliderGrounded;
        [SerializeField] private float _colliderIsGroundedPositionY;
        [SerializeField] private float _colliderIsGroundedScaleX;

        // STUN
        [SerializeField] private bool _isStun;
        private float _stunTimer = 2f;
        private float _stunForce = 500f;
    
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
            foreach (GoatData goatData in GoatsDatas)
            {
                if (PlayerOne && GlobalVariable.GoatNamePlayer1 == goatData.name)
                {
                    GoatData = goatData;
                    //Debug.Log("Player 1 IN GAME " + goatData.name);
                }
                if (PlayerOne == false && GlobalVariable.GoatNamePlayer2 == goatData.name)
                {
                    GoatData = goatData;
                    //Debug.Log("Player 2 IN GAME " + goatData.name);
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
            Debug.Log("<color=purple> la vélocity est </color>" + rb2d.velocity.x);
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
            OnJumpStay();
            
            if (rb2d.velocity.y < -0.5f)
            {
                rb2d.gravityScale = 6f;
            }
            else
            {
                rb2d.gravityScale = 3.5f;
            }
            
            if (_isJumping == false)
            {
                OnJumpStop();
            }

            if (_isJumping)
            {
                OnJumpStay();
            }
            
            // DASH STUN
            if (IsDashing && _spriteRenderer.flipX)
            {
                _dashAttackColliderRight.SetActive(true);
            }
            else
            {
                _dashAttackColliderRight.SetActive(false);
            }

            if (IsDashing && _spriteRenderer.flipX == false)
            {
                _dashAttackColliderLeft.SetActive(true);
            }
            else
            {
                _dashAttackColliderLeft.SetActive(false);
            }
            
            // ANIMATION 
            if (IsDashing)
            {
                _animator.SetBool("IsDashing", true);
                //Debug.Log("<color=yellow> animator is Dashing True </color>");
            }
            else
            {
                _animator.SetBool("IsDashing", false);
                //Debug.Log("<color=yellow> animator is Dashing False </color>");
            }
            
            if (CanJump == false)
            {
                _animator.SetBool("IsFalling", true);
                //Debug.Log("<color=orange> Animator Falling True </color>");
            }
            else
            {
                _animator.SetBool("IsFalling", false);
                //Debug.Log("<color=orange> Animator Falling False </color>");
            }

            if (_isStun)
            {
                //Debug.Log("<color=black> animator Stun True </color>");
                _animator.SetBool("IsStun", true);
            }
            else
            {
                //Debug.Log("<color=black> animator Stun False </color>");
                _animator.SetBool("IsStun", false);
            }
        }

        private void FixedUpdate()
        {
            if (_isStun == false)
            {
                OnMove();
            }
            else
            {
                var vector2 = rb2d.velocity;
                vector2.x = 0f;
                rb2d.velocity = vector2;
            }
            _animator.SetFloat("Horizontal", Mathf.Abs(rb2d.velocity.x));
            //Debug.Log("<color=cyan> Animator Horizontal </color>" + Mathf.Abs(rb2d.velocity.x));
        }
    
        // SAUT
        public void OnJump()
        {
            bool Release;
            
            if (CanJump && _isJumping == false && IsDashing == false && _isStun == false)
            {
                rb2d.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                _isJumping = true;
                _jumpTimeCounter = 0f;
                
                _animator.SetTrigger("IsJumping");
                Debug.Log("<color=magenta> animator IsJumping </color>");
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
        public void OnAttaque(float buttonValue)
        {
            if (_canAttaque && rb2d.velocity.x is <= 0.1f and >= -0.1f && _isStun == false)
            {
                // ATTAQUE DROITE
                if (_spriteRenderer.flipX)
                {
                    Debug.DrawRay(transform.position, Vector2.right * _rangeAttaque, Color.blue, 1f);
                    RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.right, _rangeAttaque, _layerMaskObstacle);
                    _hitResult = hit2D;

                    _canAttaque = false;
                    StartCoroutine("RealoadAttaque");
                    
                    _animator.SetTrigger("IsAttack");
                    Debug.Log("<color=lime> animator Attaque </color>");
                }
                // ATTAQUE GAUCHE
                else
                {
                    Debug.DrawRay(transform.position, -Vector2.right * _rangeAttaque, Color.blue, 1f);
                    RaycastHit2D hit2D = Physics2D.Raycast(transform.position, -Vector2.right, _rangeAttaque, _layerMaskObstacle);
                    _hitResult = hit2D;
                
                    _canAttaque = false;
                    StartCoroutine("RealoadAttaque");
                    
                    _animator.SetTrigger("IsAttack");
                    Debug.Log("<color=lime> animator Attaque </color>");
                }
        
                
                // JOUER AVEC CE QUE LE RAYCAST A TOUCHER
                if (_hitResult.collider != null)
                {
                    _hitResult.collider.gameObject.GetComponent<Obstacle>().Health -= _damage;
                    if (_hitResult.collider.gameObject.GetComponent<Obstacle>().Health <= 0)
                    {
                        Destroy(_hitResult.collider.gameObject);
                    }
                }
            }
        }

        public IEnumerator RealoadAttaque()
        {
            yield return new WaitForSeconds(1f);
            _canAttaque = true;
        }

        // DASH
        public void OnDash()
        {
            if (IsDashing == false && CanDash && CanJump && IsDashing == false && _isStun == false)
            {
                if (_spriteRenderer.flipX)
                {
                    _playerInputHandler.Move.x = _dashPower;
                
                    _animator.SetBool("IsDashing", true);

                }
                else
                {
                    _playerInputHandler.Move.x = -_dashPower;
                
                    _animator.SetBool("IsDashing", false); 
                }
                IsDashing = true;
                
                CanDash = false;
                StartCoroutine(DashDelaying());
            }
        }
        public IEnumerator DashDelaying()
        {
            yield return new WaitForSeconds(_dashDelay);
            IsDashing = false;
            _playerInputHandler.Move.x = 0;
            yield return new WaitForSeconds(_dashReload);
            CanDash = true;
        }

        public void OnStun()
        {
            _isStun = true;
            StartCoroutine("DelayStun");
            rb2d.AddForce(Vector2.up * _stunForce);
        }

        private IEnumerator DelayStun()
        {
            yield return new WaitForSeconds(_stunTimer);
            _isStun = false;
        }

        public void Kill()
        {
            _playerInputHandler.Move.x = 0;
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
            IsDashing = false;
        }

        public void Respawn()
        {
            rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
