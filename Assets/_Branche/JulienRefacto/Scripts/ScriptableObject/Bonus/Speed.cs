using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Speed", menuName = "ScriptableObject/Power/Speed")]
public class Speed : Power
{
    public override void Use(Player player)
    {
        Debug.Log("Use Speed");
    }
}
