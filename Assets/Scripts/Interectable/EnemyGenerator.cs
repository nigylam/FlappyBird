using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private ObjectTrigger _removerTrigger;
    [SerializeField] private BulletGenerator _bulletGenerator;

    private ObjectPool<Enemy> _pool;
    private ObjectRemover<Enemy> _remover;
    private Coroutine _generateCoroutine;
    private WaitForSeconds _generateWait;
    private WaitForSeconds _startWait;
    private float _startDelay = 0.1f;

    private void Awake()
    {
        _pool = new ObjectPool<Enemy>(_enemyPrefab, _container);
        _remover = new ObjectRemover<Enemy>(_pool);
        _generateWait = new WaitForSeconds(_delay);
        _startWait = new WaitForSeconds(_startDelay);
    }

    private void OnEnable()
    {
        _removerTrigger.Triggered += _remover.OnTrigger;
    }

    private void OnDisable()
    {
        _removerTrigger.Triggered -= _remover.OnTrigger;
    }

    public void Reset()
    {
        if (_generateCoroutine != null)
            StopCoroutine(_generateCoroutine);

        _pool.Reset();
        _bulletGenerator.Reset();
        _generateCoroutine = StartCoroutine(GenerateEnemies());
    }

    private IEnumerator GenerateEnemies()
    {
        yield return _startWait;

        while (enabled)
        {
            Spawn();
            yield return _generateWait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_lowerBound, _upperBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, 0);
        var enemy = _pool.GetObject(spawnPoint);

        if (enemy.IsInitialized == false)
            enemy.Initialize(_bulletGenerator);

        enemy.Shoted += RemoveShoted;
    }

    private void RemoveShoted(Enemy enemy)
    {
        enemy.Shoted -= RemoveShoted;
        _remover.Remove(enemy);
    }
}
