using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/Player")]
public class PlayerData : ScriptableObject
{
    public float Speed;
    public float Damage;

    public GameObject VisuelPrefab;
}
