using System.Collections;
using UnityEngine;

public class EnemyGenerator : Generator<Enemy>
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private BulletGenerator _bulletGenerator;

    private Coroutine _generateCoroutine;
    private WaitForSeconds _generateWait;
    private WaitForSeconds _startWait;
    private float _startDelay = 0.1f;

    protected override void Awake()
    {
        base.Awake();
        _generateWait = new WaitForSeconds(_delay);
        _startWait = new WaitForSeconds(_startDelay);
    }

    public override void Reset()
    {
        if (_generateCoroutine != null)
            StopCoroutine(_generateCoroutine);

        base.Reset();

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
        
        var enemy = Generate(spawnPoint);

        if (enemy.IsInitialized == false)
            enemy.Initialize(_bulletGenerator);

        enemy.RandomShoot();
    }
}
