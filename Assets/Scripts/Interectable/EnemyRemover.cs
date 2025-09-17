using UnityEngine;

public class EnemyRemover : MonoBehaviour
{
    private ObjectPool<Enemy> _pool;

    public void Initialize(ObjectPool<Enemy> pool)
    {
        _pool = pool;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            _pool.PutObject(enemy);
        }
    }

}
