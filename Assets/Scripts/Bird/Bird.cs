using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(BirdCollisionHandler))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(BirdShooter))]
[RequireComponent(typeof(UserInput))]
public class Bird : MonoBehaviour
{
    private BirdMover _mover;
    private ScoreCounter _scoreCounter;
    private BirdCollisionHandler _handler;
    private BirdShooter _shooter;
    private UserInput _userInput;

    public event Action GameOver;

    private void Awake()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
        _mover = GetComponent<BirdMover>();
        _handler = GetComponent<BirdCollisionHandler>();
        _shooter = GetComponent<BirdShooter>();
        _userInput = GetComponent<UserInput>();

        _shooter.Initialize(_userInput);
        _mover.Initialize(_userInput);
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
        _shooter.Reset();
        _userInput.Reset();
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if(interactable is IDamaging)
        {
            GameOver?.Invoke();
            _userInput.Freeze();
        }
        else if(interactable is ScoreZone)
        {
            _scoreCounter.Add();
        }
    }
}
