using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Scripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Obstacle : MonoBehaviour
{
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
