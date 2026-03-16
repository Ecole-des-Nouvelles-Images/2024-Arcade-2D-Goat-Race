using UnityEngine;

[CreateAssetMenu(fileName = "Spike", menuName = "ScriptableObject/Power/Spike")]
public class Spike : Power
{
    public override void Use(Player player)
    {
        Debug.Log("Use Spike");
    }
}
