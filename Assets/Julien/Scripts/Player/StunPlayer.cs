using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Julien.Scripts;
using UnityEngine;

public class StunPlayer : MonoBehaviour
{
  private Transform _transform;
  private Transform _defaultTransform;

  private void Awake()
  {
    _transform = gameObject.transform;
    _defaultTransform = gameObject.transform;
    _defaultTransform.localScale = new Vector3(0, 0, 0);
  }

  private void OnEnable()
  {
    transform.DOScale(3f, 0.2f);
  }

  private void OnDisable()
  {
    _defaultTransform.localScale = new Vector3(0, 0, 0);
  }

  private void OnTriggerStay2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      Goat goat = other.GetComponent<Goat>();
      Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
      
      goat.OnStun();
    }
  }
}
