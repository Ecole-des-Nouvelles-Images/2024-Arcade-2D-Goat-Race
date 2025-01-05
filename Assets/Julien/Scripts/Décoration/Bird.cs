using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bird : MonoBehaviour
{
   private BoxCollider2D _boxCollider2D;

   private float _randomPositionX;
   private float _randomPositionY;
   private Vector2 _randomPosition;
   private float _speed;
   
   private bool _move;
   private void Start()
   {
      _speed = Random.Range(2f, 4f);
      _randomPositionY = Random.Range(0, 30);
      _randomPositionX = Random.Range(-40, 40);
      _randomPosition = new Vector2(_randomPositionX, _randomPositionY);
      
      _boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
        birdFly();
        _move = true;
      }
   }

   private void Update()
   {
      if (_move)
      {
         gameObject.transform.localPosition = Vector3.Lerp(transform.localPosition, _randomPosition , _speed * Time.deltaTime);
      }
   }

   private void birdFly()
   {

   }
}
