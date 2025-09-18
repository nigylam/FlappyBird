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
            _pool.PutObject(obj as T);
    }
}
