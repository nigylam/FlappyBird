using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private PipeGroup _prefab;

    private Queue<PipeGroup> _pool;
    private List<PipeGroup> _activePipes;

    public IEnumerable<PipeGroup> PooledOjects => _pool;

    private void Awake()
    {
        _pool = new Queue<PipeGroup>();
        _activePipes = new List<PipeGroup>();
    }

    public PipeGroup GetObject()
    {
        PipeGroup pipe;

        if (_pool.Count == 0)
        {
            pipe = Instantiate(_prefab);
            pipe.transform.parent = _container;
        }
        else
        {
            pipe = _pool.Dequeue();
        }

        _activePipes.Add(pipe);
        pipe.gameObject.SetActive(true);

        return pipe;
    }

    public void PutObject(PipeGroup pipe)
    {
        _activePipes.Remove(pipe);
        _pool.Enqueue(pipe);
        pipe.gameObject.SetActive(false);
    }

    public void Reset()
    {
        if (_activePipes.Count > 0)
        {
            for (int i = _activePipes.Count - 1; i >= 0; i--)
            {
                PutObject(_activePipes[i]);
            }
        }
    }
}
