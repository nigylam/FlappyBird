using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private ObjectTrigger _removerTrigger;

    private ObjectPool<Bullet> _pool;
    private ObjectRemover<Bullet> _remover;

    private void Awake()
    {
        _pool = new ObjectPool<Bullet>(_bulletPrefab, _container);
        _remover = new ObjectRemover<Bullet>(_pool);
    }

    private void OnEnable()
    {
        _removerTrigger.Triggered += _remover.OnTrigger;
    }

    private void OnDisable()
    {
        _removerTrigger.Triggered -= _remover.OnTrigger;
    }

    public void Generate(Vector2 spawnPoint)
    {
        var bullet = _pool.GetObject(spawnPoint);
        bullet.Collided += RemoveCollided;
    }

    public void RemoveCollided(Bullet bullet)
    {
        bullet.Collided -= RemoveCollided;
        _remover.Remove(bullet);
    }

    public void Reset()
    {
        _pool.Reset();
    }
}
