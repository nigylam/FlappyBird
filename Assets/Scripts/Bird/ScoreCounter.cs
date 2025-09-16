using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _scores;

    public event Action<int> Changed;

    public void Add()
    {
        _scores++;
        Changed?.Invoke(_scores);
    }

    public void Reset()
    {
        _scores = 0;
        Changed?.Invoke(_scores);
    }
}
