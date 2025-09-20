using UnityEngine;

public class Enemy : Damager
{
    private const string CharacterTag = "Player";

    [SerializeField] private float _shootProbability;
    [SerializeField] private float _bulletPositionOffset;

    private BulletGenerator _bulletGenerator;

    public bool IsInitialized { get; private set; } = false;

    public void Initialize(BulletGenerator bulletGenerator)
    {
        _bulletGenerator = bulletGenerator;
        IsInitialized = true;
    }

    public void RandomShoot()
    {
        if (Random.Range(0f, 1f) <= _shootProbability)
            Shoot();
    }

    private void Shoot()
    {
        _bulletGenerator.Generate(new Vector2(transform.position.x + _bulletPositionOffset, transform.position.y));
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(CharacterTag))
            base.OnTriggerEnter2D(collision);
    }
}
