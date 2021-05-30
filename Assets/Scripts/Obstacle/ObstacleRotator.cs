using UnityEngine;
using DG.Tweening;

public class ObstacleRotator : MonoBehaviour
{
    [SerializeField] private float _animationDuration;
    [SerializeField] private int _degreeRotation;
    private void Start()
    {
        transform.DORotate(new Vector3(0, _degreeRotation, 0), _animationDuration, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo);
    }
}
