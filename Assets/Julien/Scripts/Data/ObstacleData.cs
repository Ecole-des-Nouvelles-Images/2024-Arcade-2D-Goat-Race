using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Obstacle", menuName = "ScriptableObject/Obstacle")]
public class ObstacleData : ScriptableObject
{
    //public ObstacleData Script;
    public string ObstableName;
    public Sprite Sprite;
    public int Health;
    public float Collider2DAxeX;
    public float Collider2DAxeY;
}
