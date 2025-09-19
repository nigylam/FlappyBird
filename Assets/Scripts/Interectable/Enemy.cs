using System;
using UnityEngine;

[RequireComponent(typeof(EnemyCollisionHandler))]
public class Enemy : MonoBehaviour, IDamaging
{
    private const string CharacterTag = "Player";

    [SerializeField] private float _shootProbability;
    [SerializeField] private float _bulletPositionOffset;

    private BulletGenerator _bulletGenerator;
    private EnemyCollisionHandler _collisionHandler;

    public bool IsInitialized { get; private set; } = false;

    public event Action<Enemy> Shoted;

    private void Awake()
    {
        _collisionHandler = GetComponent<EnemyCollisionHandler>();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += ProcessCollision;

        if (IsInitialized)
            RandomShoot();
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= ProcessCollision;
    }

    public void Initialize(BulletGenerator bulletGenerator)
    {
        _bulletGenerator = bulletGenerator;
        IsInitialized = true;

        RandomShoot();
    }

    private void RandomShoot()
    {
        if (UnityEngine.Random.Range(0f, 1f) <= _shootProbability)
            Shoot();
    }

    private void Shoot()
    {
        _bulletGenerator.Generate(new Vector2(transform.position.x + _bulletPositionOffset, transform.position.y));
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if ((interactable as MonoBehaviour).gameObject.CompareTag(CharacterTag))
            Shoted?.Invoke(this);
    }
}
