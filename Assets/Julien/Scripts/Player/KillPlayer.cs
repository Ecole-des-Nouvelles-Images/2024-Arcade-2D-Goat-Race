using System;
using System.Collections;
using System.Collections.Generic;
using Julien.Scripts;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public Vector3 SpawnPosition;
    private Goat _goat;
    [SerializeField] private float SpeedTeleportation = 5f;

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

    public void Kill()
    {
        _goat.Respawn();
        transform.position = Vector3.Lerp(gameObject.transform.position, SpawnPosition, SpeedTeleportation * Time.deltaTime);
    }
}
