using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    [SerializeField] private ParticleSystem _destroyEffect;

    private MeshRenderer _meshRenderer;

    public event UnityAction<Block> BulletHit;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetColor(Color color)
    {
        _meshRenderer.material.color = color;
    }

    public void Break()
    {
        BulletHit?.Invoke(this);
        Instantiate(_destroyEffect, transform.position, _destroyEffect.transform.rotation);
        Destroy(gameObject);
    }

}
