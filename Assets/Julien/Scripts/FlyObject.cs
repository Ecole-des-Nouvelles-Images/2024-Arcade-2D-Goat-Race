using System.Collections;
using DG.Tweening;
using UnityEngine;

public class FlyObject : MonoBehaviour
{
    [SerializeField] private AnimationCurve _animationCurve = AnimationCurve.EaseInOut(0,0,1,1);
    [SerializeField] private AnimationCurve _endAnimationCurve = AnimationCurve.EaseInOut(0,0,1,1);
    
    private bool _up = true;
    [SerializeField] private float _speed;
    private void Start()
    {
        Up();
    }
    private void Up()
    {
        transform.transform.DOMove(transform.position + new Vector3(0, 0.5f, 0), _speed).SetEase(_animationCurve);
        StartCoroutine("Delay");
        _up = false;
    }
    private void Down()
    {
        transform.transform.DOMove(transform.position + new Vector3(0, -0.5f, 0), _speed).SetEase(_endAnimationCurve);
        StartCoroutine("Delay");
        _up = true;
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(_speed);
        if (_up)
        {
            Up();
        }
        else
        {
            Down();
        }
    }
}
