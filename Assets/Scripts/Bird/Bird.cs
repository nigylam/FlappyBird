using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(BirdCollisionHandler))]
[RequireComponent(typeof(ScoreCounter))]
public class Bird : MonoBehaviour
{
    private BirdMover _mover;
    private ScoreCounter _scoreCounter;
    private BirdCollisionHandler _handler;

    public event Action GameOver;

    private void Awake()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
        _mover = GetComponent<BirdMover>();
        _handler = GetComponent<BirdCollisionHandler>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    public void Reset()
    {
        _mover.Reset();
        _scoreCounter.Reset();
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if(interactable is Pipe || interactable is Ground)
        {
            GameOver?.Invoke();
            _mover.Freeze();
        }
        else if(interactable is ScoreZone)
        {
            _scoreCounter.Add();
        }
    }
}
