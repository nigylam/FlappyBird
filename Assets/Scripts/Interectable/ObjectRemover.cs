using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out PipeGroup pipe))
        {
            _pool.PutObject(pipe);
        }
    }

}
