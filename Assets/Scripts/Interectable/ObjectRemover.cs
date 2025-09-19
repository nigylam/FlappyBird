using UnityEngine;

public class ObjectRemover<T> where T : MonoBehaviour, IInteractable
{
    private ObjectPool<T> _pool;

    public ObjectRemover(ObjectPool<T> pool)
    {
        _pool = pool;
    }

    public void OnTrigger(IInteractable obj)
    {
        if (obj is T)
            Remove(obj as T);
    }

    public void Remove(T obj)
    {
        _pool.PutObject(obj);
    }
}
