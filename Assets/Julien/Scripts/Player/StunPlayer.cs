using System.Collections;
using DG.Tweening;
using Julien.Scripts;
using UnityEngine;

public class StunPlayer : MonoBehaviour
{
  [SerializeField] private AnimationCurve _animationCurve = AnimationCurve.EaseInOut(0,0,1,1);
  [SerializeField] private AnimationCurve _endAnimationCurve = AnimationCurve.EaseInOut(0,0,1,1);
  [SerializeField] private float _endValueStart;
  [SerializeField] private float _endValueEnd;
  [SerializeField] private float _duration; 
  [SerializeField] private float _durationEnd;
  private Transform _defaultTransform;
  

  private void Awake()
  {
    _defaultTransform = gameObject.transform;
    _defaultTransform.localScale = new Vector3(0, 0, 0);
  }

  private void OnEnable()
  {
    transform.DOScale(_endValueStart, _duration).SetEase(_animationCurve);
    StartCoroutine("Retracte");
  }

  private IEnumerator Retracte()
  {
    yield return new WaitForSeconds(1.8f);
    transform.DOScale(_endValueEnd, _durationEnd).SetEase(_endAnimationCurve);
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
