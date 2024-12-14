using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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
   
    private void Start()
    {
        LoadObstacle();
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _maxHealth = Health;
        
    }

    private void Update()
    {
        Slider.value = Health / _maxHealth;
        
        var spriteRendererColor = SpriteRenderer.color;
        
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

    public void Damaged()
    {
        _damageParticle.SetActive(true);
        StartCoroutine("DelayDamage");
    }

    private IEnumerator DelayDamage()
    {
        yield return new WaitForSeconds(0.5f);
        _damageParticle.SetActive(false);
    }
    public void Destroyed()
    {
        _destroyParticle.SetActive(true);
    }
}
