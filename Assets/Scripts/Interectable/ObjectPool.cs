using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private T _prefab;

    private Queue<T> _pool;
    private List<T> _activeObjects;

    public IEnumerable<T> PooledOjects => _pool;

    private void Awake()
    {
        _pool = new Queue<T>();
        _activeObjects = new List<T>();
    }

    public T GetObject()
    {
        T obj;

        if (_pool.Count == 0)
        {
            obj = Instantiate(_prefab, _container);
        }
        else
        {
            obj = _pool.Dequeue();
        }

        _activeObjects.Add(obj);
        obj.gameObject.SetActive(true);

        return obj;
    }

    public void PutObject(T obj)
    {
        _activeObjects.Remove(obj);
        _pool.Enqueue(obj);
        obj.gameObject.SetActive(false);
    }

    public void Reset()
    {
        if (_activeObjects.Count > 0)
        {
            for (int i = _activeObjects.Count - 1; i >= 0; i--)
            {
                PutObject(_activeObjects[i]);
            }
        }
    }
}
