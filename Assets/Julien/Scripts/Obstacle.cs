using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using SpriteRenderer = UnityEngine.SpriteRenderer;

public class Obstacle : MonoBehaviour
{
    public Slider Slider;
    
    [SerializeField] private bool DecresseColor = true;
    [SerializeField] private float _currentColor = 1;
    [SerializeField] private float _colorSpeed;
    [SerializeField] private float MaxBlueValue = 0.6f;
    
    public ObstacleData ObstacleData;

    public SpriteRenderer SpriteRenderer;
    public string Name;
    [SerializeField] private float _maxHealth;
    public float Health;
    public BoxCollider2D BoxCollider2D;
    
   public float SizeX;
   public float SizeY;
   public float OffsetY;

   [Header("<color=green> Particle </color>")] 
   
   [SerializeField] private GameObject _damageParticle;
   [SerializeField] private GameObject _destroyParticle;
   [SerializeField] private float _timer;
   
   private Color _color;
   private BoxCollider2D _boxCollider2D;
   private bool _destroyed;
   private bool _canRespawn;
   private AudioSource _audioSource;
  [SerializeField] private SongSFX _songSfx;
   
    private void Start()
    {
        LoadObstacle();
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _maxHealth = Health;
        
        _boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        _audioSource = gameObject.GetComponent<AudioSource>();
        _songSfx = GameObject.Find("SFXManager").GetComponent<SongSFX>();
    }

    private void Update()
    {
        Slider.value = Health / _maxHealth;
        
        var spriteRendererColor = SpriteRenderer.color;

        if (!_destroyed)
        {
            if (DecresseColor)
            {
                SpriteRenderer.color = new Color(1,1,spriteRendererColor.b -= _colorSpeed * Time.deltaTime);
            }
            else
            {
                SpriteRenderer.color = new Color(1,1,spriteRendererColor.b += _colorSpeed * Time.deltaTime);
            }
        
            if (spriteRendererColor.b >= 1)
            {
                DecresseColor = true;
            }

            if (spriteRendererColor.b <= 0.6f)
            {
                DecresseColor = false;
            } 
        }

        bool DecressTimer;

        if (_canRespawn) DecressTimer = true; else DecressTimer = false;
        this.DecressTimer(DecressTimer);
        
    }

    public void LoadObstacle()
    {
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        BoxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        
        SpriteRenderer.sprite = ObstacleData.Sprite;
        Name = ObstacleData.name;
        Health = ObstacleData.Health;
        
        
        SizeX = ObstacleData.Collider2DAxeX;
        SizeY = ObstacleData.Collider2DAxeY;
        OffsetY = ObstacleData.OffsetColliderY;
        
        BoxCollider2D.size = new Vector2(SizeX,SizeY);
        BoxCollider2D.offset = new Vector2(0,OffsetY);
    }

    public void DecressTimer(bool decress)
    {
        if (decress)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0) Respawn();
        }
    }
    
    public void Damaged(int damage)
    {
        
        _damageParticle.GetComponent<ParticleSystem>().Play();
        Health -= damage;
        Slider.gameObject.SetActive(true);
        transform.transform.DOShakeScale(0.1f, new Vector3(-0.3f,0), 3);
        
        _audioSource.clip = _songSfx.AudioDamage[Random.Range(0,_songSfx.AudioDamage.Count)];
        _audioSource.Play();

        if (Health <= 0)
        {
            Destroyed();
            _audioSource.clip = _songSfx.AudioDestroy[Random.Range(0,_songSfx.AudioDestroy.Count)];
            _audioSource.Play();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) _canRespawn = false;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) _canRespawn = true;
    }

    public void Destroyed()
    {
        GameObject NewParticle = _destroyParticle;
        
        Instantiate(NewParticle, _destroyParticle.transform.position, Quaternion.identity);
        NewParticle.GetComponent<DestroyParticle>().Particle();

        _destroyed = true;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        Slider.gameObject.SetActive(false);
        Debug.Log("change le color");
        _boxCollider2D.isTrigger = true;
        _canRespawn = true;
    }
    public void Respawn()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        _boxCollider2D.isTrigger = false;
        _destroyed = false;
        Health = _maxHealth;
        _timer = 7f;
        _canRespawn = false;
    }
}
