using IJunior.TypedScenes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    private TowerBuilder _towerBuilder;
    private List<Block> _blocks;

    public event UnityAction<int> SizeUpdated;

    private void Start()
    {
        _towerBuilder = GetComponent<TowerBuilder>();
        _blocks = _towerBuilder.Build();

        foreach (var block in _blocks)
        {
            block.BulletHit += OnBulletHit;
        }
        SizeUpdated?.Invoke(_blocks.Count);
    }

    private void OnBulletHit(Block hitBlock)
    {
        hitBlock.BulletHit -= OnBulletHit;
        _blocks.Remove(hitBlock);

        foreach (var block in _blocks)
        {
            block.transform.position = new Vector3(block.transform.position.x, block.transform.position.y - block.transform.localScale.y * 2, block.transform.position.z);
        }
        SizeUpdated?.Invoke(_blocks.Count);
        CheckNumberBlocks();
    }

    private void CheckNumberBlocks()
    {
        if (_blocks.Count == 0) Menu.Load();
    }
}
