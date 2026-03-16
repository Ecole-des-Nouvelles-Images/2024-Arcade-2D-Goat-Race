using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Power", menuName = "ScriptableObject/Power")]
public abstract class Power : ScriptableObject
{
    public abstract void Use(Player player);
}
