using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Obstacle", menuName = "ScriptableObject/Goat")]
public class GoatData : ScriptableObject
{
    public string Name;
    public Sprite Sprite;
    public RuntimeAnimatorController AnimatorController;
    public int Damage;
    public float RangeAttaque;
    public float Speed;
    public float JumpForce;
    public float RayDistance;
    
    public float Collider2DAxeX;
    public float Collider2DAxeY;

    public float ColliderIsGroundedPositionY;
    public float ColliderIsGroundedScaleX;

    // La caméra distance doit être égal à Collider2DAxeY
    public float CameraZ;
    public float CameraY;
    public float CameraX;
    
}
