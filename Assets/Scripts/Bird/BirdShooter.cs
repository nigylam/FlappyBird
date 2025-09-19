using UnityEngine;

public class BirdShooter : MonoBehaviour
{
    [SerializeField] private UserInput _userInput;
    [SerializeField] private BulletGenerator _bulletGenerator;

    [SerializeField] private float _bulletOffset;

    private void OnEnable()
    {
        _userInput.ShootKeyPressed += Shoot;
    }

    private void OnDisable()
    {
        _userInput.ShootKeyPressed -= Shoot;
    }

    public void Initialize(UserInput userInput)
    {
        _userInput = userInput;
    }

    public void Reset()
    {
        _bulletGenerator.Reset();
    }

    private void Shoot()
    {
        _bulletGenerator.Generate(new Vector2(transform.position.x + _bulletOffset, transform.position.y));
    }
}
