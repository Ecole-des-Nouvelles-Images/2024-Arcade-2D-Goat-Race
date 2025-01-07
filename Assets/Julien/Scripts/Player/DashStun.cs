using System;
using System.Collections;
using System.Collections.Generic;
using Julien.Scripts;
using UnityEngine;

public class DashStun : MonoBehaviour
{
    private bool AsAttack = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Goat>().OnStun();
        }
    }
}
