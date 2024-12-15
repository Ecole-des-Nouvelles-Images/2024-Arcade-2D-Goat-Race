using UnityEngine;
using Random = UnityEngine.Random;


public class AutoDestroyBonus : MonoBehaviour
{
    private void Start()
    {
        int RandomIndex = Random.Range(1, 4);
        
        if (RandomIndex > 2)
        {
            Destroy(gameObject);
        }
    }
}
