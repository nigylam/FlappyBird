using UnityEngine;

public class EnemyRemover : MonoBehaviour
{
    [SerializeField] private ObjectPool<Enemy> _pool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            _pool.PutObject(enemy);
        }
    }

}
