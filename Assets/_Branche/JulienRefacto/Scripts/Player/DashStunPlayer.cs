using System;
using UnityEngine;

public class DashStunPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponentInParent<Player>().Stun();
        }
    }
}
