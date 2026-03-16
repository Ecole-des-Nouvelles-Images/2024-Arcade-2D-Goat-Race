using UnityEngine;

public class VisualPrefab : MonoBehaviour
{
    public GameObject LeftCollider;
    public GameObject RightCollider;
    public GameObject GroundChecker;
    public Animator Animator;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }
}
