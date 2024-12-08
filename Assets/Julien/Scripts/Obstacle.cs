using System;
using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private bool DecresseColor = true;
    [SerializeField] private float _currentColor = 1;
    [SerializeField] private float _colorSpeed;
    [SerializeField] private float MaxBlueValue = 0.6f;
    
    public ObstacleData ObstacleData;

    public SpriteRenderer SpriteRenderer;
    public string Name;
    public int Health;
    public BoxCollider2D BoxCollider2D;
    
   public float SizeX;
   public float SizeY;
    private void Start()
    {
        LoadObstacle();
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        
        
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
        Debug.Log(spriteRendererColor.b);
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

        BoxCollider2D.size = new Vector2(SizeX,SizeY);
    }
}
