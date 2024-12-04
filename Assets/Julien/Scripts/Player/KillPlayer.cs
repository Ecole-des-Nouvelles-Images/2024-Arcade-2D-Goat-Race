using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public Vector3 SpawnPosition;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("GroundKill"))
        {
            Kill();
        }
    }

    public void Kill()
    {
        gameObject.transform.position = SpawnPosition;
    }
}
