using System;
using UnityEngine;

public class Bullet : MonoBehaviour, IDamaging
{
    [SerializeField] private float _speed;
    [SerializeField] private float _directionX;

    public Action<Bullet> Collided;

    private void Update()
    {
        transform.Translate(new Vector2(_directionX, 0).normalized * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(gameObject.tag) == false)
            Collided?.Invoke(this);
    }

}
