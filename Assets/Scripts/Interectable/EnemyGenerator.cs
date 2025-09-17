using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private ObjectPool<Enemy> _pool;
    [SerializeField] private EnemyRemover _remover;

    private Coroutine _generateCoroutine;
    private WaitForSeconds _generateWait;
    private WaitForSeconds _startWait;
    private float _startDelay = 0.1f;

    private void Awake()
    {
        _generateWait = new WaitForSeconds(_delay);
        _startWait = new WaitForSeconds(_startDelay);
    }

    public void Reset()
    {
        if( _generateCoroutine != null)
            StopCoroutine(_generateCoroutine);

        _pool.Reset();
        _generateCoroutine = StartCoroutine(GeneratePipes());
    }

    private IEnumerator GeneratePipes()
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
        var pipe = _pool.GetObject();
        pipe.transform.position = spawnPoint;
    }
}
