using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
   [SerializeField] private bool _player1Layer;
   
   public GameObject Plan1;
   public GameObject Plan2;
   public GameObject Plan3;

   [SerializeField] private float _speedPlan1;
   [SerializeField] private float _speedPlan2;
   [SerializeField] private float _speedPlan3;

   [SerializeField] private GameObject _player;
   [SerializeField] private Rigidbody2D _rb2dPlayer;

   private void Awake()
   {
      _rb2dPlayer = _player.GetComponent<Rigidbody2D>();
   }

   private void FixedUpdate()
   {
      // PLAN 1
      if (_rb2dPlayer.velocity.x > 0)
      {
         Plan1.gameObject.transform.Translate(Vector3.right * (_speedPlan1 * Time.deltaTime));
      }
      else if (_rb2dPlayer.velocity.x < 0)
      {
         Plan1.gameObject.transform.Translate(Vector3.right * (-_speedPlan1 * Time.deltaTime));
      }
      
      // PLAN 2
      if (_rb2dPlayer.velocity.x > 0)
      {
         Plan2.gameObject.transform.Translate(Vector3.right * (_speedPlan2 * Time.deltaTime));
      }
      else if (_rb2dPlayer.velocity.x < 0)
      {
         Plan2.gameObject.transform.Translate(Vector3.right * (-_speedPlan2 * Time.deltaTime));
      }
      
      // PLAN 3
      if (_rb2dPlayer.velocity.x > 0)
      {
         Plan3.gameObject.transform.Translate(Vector3.right * (_speedPlan3 * Time.deltaTime));
      }
      else if (_rb2dPlayer.velocity.x < 0)
      {
         Plan3.gameObject.transform.Translate(Vector3.right * (-_speedPlan3 * Time.deltaTime));
      }
   }

   private void Update()
   {
      Debug.Log(_rb2dPlayer.velocity.x);
      
      if (_player1Layer)
      {
         gameObject.layer = LayerMask.NameToLayer("Paralax1");
      }
      else
      {
         gameObject.layer = LayerMask.NameToLayer("Paralax2");
      }
   }
}
