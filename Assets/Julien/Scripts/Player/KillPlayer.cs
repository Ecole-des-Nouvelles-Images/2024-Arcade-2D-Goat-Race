using System.Collections;
using Julien.Scripts;
using UnityEngine;

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
        StartCoroutine("Revive");
    }

    private IEnumerator Revive()
    {
        yield return new WaitForSeconds(TimeToRespawn);
        _goat.Respawn();
        _isDead = false;
    }
}
