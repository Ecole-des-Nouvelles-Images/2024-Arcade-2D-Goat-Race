using DG.Tweening;
using Julien.Scripts;
using UnityEngine;

public class StunPlayer : MonoBehaviour
{
  private Transform _defaultTransform;

  private void Awake()
  {
    _defaultTransform = gameObject.transform;
    _defaultTransform.localScale = new Vector3(0, 0, 0);
  }

  private void OnEnable()
  {
    transform.DOScale(1.3f, 0.2f);
  }

  private void OnDisable()
  {
    _defaultTransform.localScale = new Vector3(0, 0, 0);
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      Goat goat = other.GetComponent<Goat>();
      goat.OnStun();
      Debug.Log("Joue le stun");
    }
  }
}
