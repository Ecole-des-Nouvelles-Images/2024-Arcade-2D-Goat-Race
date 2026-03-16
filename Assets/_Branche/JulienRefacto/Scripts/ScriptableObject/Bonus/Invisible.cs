using UnityEngine;

[CreateAssetMenu(fileName = "Invisibility", menuName = "ScriptableObject/Power/Invisibility")]
public class Invisible : Power
{
    public override void Use(Player player)
    {
        Debug.Log("Use Invisibility");
    }
}
