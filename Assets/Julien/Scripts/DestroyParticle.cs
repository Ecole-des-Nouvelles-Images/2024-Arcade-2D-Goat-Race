using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
   public void Particle()
   {
      gameObject.GetComponent<ParticleSystem>().Play();
      Debug.Log("joue les particle");
   }
}
