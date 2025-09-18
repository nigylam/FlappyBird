using UnityEngine;

public class Bullet : MonoBehaviour, IDamaging
{
    [SerializeField] private float _speed;
    [SerializeField] private float _directionX;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(new Vector2(_directionX, 0).normalized * _speed * Time.deltaTime);
    }
}
