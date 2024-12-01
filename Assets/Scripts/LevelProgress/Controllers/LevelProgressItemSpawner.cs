using System.Collections.Generic;
using UnityEngine;

public class LevelProgressItemSpawner : MonoBehaviour
{
    private Queue<LevelProgressItem> _itemsQueue;

    [SerializeField] private LevelProgressItem _itemPrefab;
    [SerializeField] private Transform _itemParentTransform;
    [SerializeField] private int _spawnObjectCount;
    [SerializeField] private int _emptyObjectCount;
    [SerializeField] private int _levelObjectCount;
    [SerializeField] private int _lastLevel;
    public LevelProgressItem ItemPrefab => _itemPrefab;

    public int LastLevel
    {
        get { return _lastLevel; }
        set { _lastLevel = value; }
    }

    public Queue<LevelProgressItem> ItemsQueue
    {
        get { return _itemsQueue; }
        set { _itemsQueue = value; }
    }

    private void Start()
    {
        _itemsQueue = new Queue<LevelProgressItem>();
        SpawnItem();
    }

    private void SpawnItem()
    {
        for(int i = 0; i < _emptyObjectCount; i++)
        {
            LevelProgressItem levelBarItem = Instantiate(_itemPrefab, _itemParentTransform);
            ItemsQueue.Enqueue(levelBarItem);

            levelBarItem.SetEmptyText();
        }
        for(int i = 0; i < _levelObjectCount; i++)
        {
            LevelProgressItem item = Instantiate(_itemPrefab, _itemParentTransform);
            _itemsQueue.Enqueue(item);
            item.SetDatas(i + 1);
        }
        _lastLevel = _levelObjectCount;
    }
}
