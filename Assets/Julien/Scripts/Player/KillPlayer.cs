using System.Collections;
using Julien.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class KillPlayer : MonoBehaviour
{
    public Vector3 SpawnPosition;
    private Goat _goat;
    private bool _isDead;
    [SerializeField] private float TimeToRespawn = 2f;
    [SerializeField] private float SpeedTeleportation = 3f;
    

    private void Awake()
    {
        _goat = GetComponent<Goat>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("GroundKill"))
        {
            Kill();
        }
    }

    private void Update()
    {
        if (_isDead)
        { 
            transform.position = Vector3.Lerp(gameObject.transform.position, SpawnPosition, SpeedTeleportation * Time.deltaTime); 
        }
    }

    public void Kill()
    {
        _goat.Kill();
        _isDead = true;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        StartCoroutine("Revive");
    }

    private IEnumerator Revive()
    {
        yield return new WaitForSeconds(TimeToRespawn);
        
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        _goat.Respawn();
        _isDead = false;
    }
}
