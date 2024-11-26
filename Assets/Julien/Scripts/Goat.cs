using System.Collections;
using UnityEngine;

namespace Julien.Scripts
{
    public class Goat : MonoBehaviour
    {
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
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _playerInputHandler = GetComponent<PlayerInputHandler>();
            rb2d = GetComponent<Rigidbody2D>();
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
        
            // COLLISION DU IS GROUNDED
            _colliderIsGroundedPositionY = GoatData.ColliderIsGroundedPositionY;
            _colliderIsGroundedScaleX = GoatData.ColliderIsGroundedScaleX;

            _colliderIsGroundedPositionY = GoatData.ColliderIsGroundedPositionY;
            _colliderIsGroundedScaleX = GoatData.ColliderIsGroundedScaleX;

            _ColliderGrounded.transform.localPosition = new Vector3(0, -_colliderIsGroundedPositionY, 0);
            _ColliderGrounded.transform.localScale = new Vector3(_colliderIsGroundedScaleX, 0.3f, 0);
        }

        public void ResetData()
        {
            
        }
    
        private void Update()
        {
            // // Jump HitGround
            // Debug.DrawRay(transform.position , Vector3.down * _rayDistance, Color.red);
            // RaycastHit2D HitGround = Physics2D.Raycast(transform.position, -Vector2.up, _rayDistance, _layerMaskGrounded);
            // CanJump = HitGround.collider;
        
        
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
        }

        private void FixedUpdate()
        {
            OnMove();
        }
    
        // SAUT
        public void OnJump()
        {
            if (CanJump)
            {
                rb2d.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
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
                if (_playerInputHandler.Move.x >= 0)
                {
                    Debug.DrawRay(transform.position, Vector2.right * _rangeAttaque, Color.blue, 1f);
                    RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.right, _rangeAttaque, _layerMaskObstacle);
                    _hitResult = hit2D;

                    _canAttaque = false;
                    StartCoroutine("RealoadAttaque");
                }
                // ATTAQUE GAUCHE
                else
                {
                    Debug.DrawRay(transform.position, -Vector2.right * _rangeAttaque, Color.blue, 1f);
                    RaycastHit2D hit2D = Physics2D.Raycast(transform.position, -Vector2.right, _rangeAttaque, _layerMaskObstacle);
                    _hitResult = hit2D;
                
                    _canAttaque = false;
                    StartCoroutine("RealoadAttaque");
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
        
            if (_playerInputHandler.Move.x >= 0 && CanDash)
            {
                _playerInputHandler.Move.x = _dashPower;
            }
            else
            {
                _playerInputHandler.Move.x = -_dashPower;
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
        }
    }
}
