using System.Collections.Generic;
using UnityEngine;

public abstract class Generator<T> : MonoBehaviour where T : Damager
{
    [SerializeField] private T _prefab;
    [SerializeField] private Transform _container;
    [SerializeField] private RemoveTrigger _removeTrigger;

    private ObjectPool<T> _pool;
    private List<T> _activeObjects;

    protected virtual void Awake()
    {
        _pool = new ObjectPool<T>(_prefab, _container);
        _activeObjects = new List<T>();
    }

    private void OnEnable()
    {
        _removeTrigger.Triggered += Remove;
    }

    private void OnDisable()
    {
        _removeTrigger.Triggered -= Remove;
    }

    public virtual T Generate(Vector2 spawnPoint)
    {
        var obj = _pool.GetObject(spawnPoint);
        obj.Collided += Remove;
        _activeObjects.Add(obj);
        return obj;
    }

    protected virtual void Remove(Damager obj)
    {
        if (obj is T)
        {
            obj.Collided -= Remove;
            _pool.PutObject(obj as T);
        }
    }

    public virtual void Reset()
    {
        if (_activeObjects.Count > 0)
        {
            foreach (var obj in _activeObjects)
                Remove(obj);
        }

        _activeObjects.Clear();
    }
}
