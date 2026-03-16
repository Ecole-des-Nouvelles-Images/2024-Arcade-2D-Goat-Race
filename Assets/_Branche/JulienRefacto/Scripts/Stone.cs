using UnityEngine;

public class Stone : MonoBehaviour, IObstacle
{
    public float MaxHealth;
    public float CurrentHealth;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Take damage");
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            DestroyObstacle();
        }
    }
    
    // Un parent ferra respawn l'obstacle au bout d'un certain temp, et vérifiera si un joueur est dedans si oui alors il arrête
    private void DestroyObstacle()
    {
        Destroy(gameObject);
    }
}
