using System;
using System.Collections;
using System.Collections.Generic;
using Julien.Scripts;
using UnityEngine;

public class DashStun : MonoBehaviour
{
    private bool AsAttack = false;
    [SerializeField] private Goat _goat;

    private void Start()
    {
        _goat = transform.parent.gameObject.GetComponent<Goat>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<Goat>().CanBeStun)
        {
            other.gameObject.GetComponent<Goat>().OnStun();
        }

        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            int BetterDamage = _goat.GoatData.Damage * 2;
            other.gameObject.GetComponent<Obstacle>().Damaged(BetterDamage);
            _goat.OnStun();
            _goat.IsDashing = false;
        }
    }
}
