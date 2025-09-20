using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour, IInteractable
{
    private readonly Transform _container;
    private readonly T _prefab;
    private readonly Queue<T> _pool;

    public ObjectPool(T prefab, Transform container = null)
    {
        _prefab = prefab;
        _container = container;
        _pool = new Queue<T>();
    }

    public T GetObject(Vector2 position)
    {
        T obj;

        if (_pool.Count == 0)
        {
            obj = Object.Instantiate(_prefab, position, Quaternion.identity, _container);
        }
        else
        {
            obj = _pool.Dequeue();
            obj.transform.position = position;
        }

        obj.gameObject.SetActive(true);

        return obj;
    }

    public void PutObject(T obj)
    {
        _pool.Enqueue(obj);
        obj.gameObject.SetActive(false);
    }
}
