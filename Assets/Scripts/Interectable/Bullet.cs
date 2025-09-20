using System;
using UnityEngine;

public class Bullet : Damager
{
    [SerializeField] private float _speed;
    [SerializeField] private float _directionX;

    private void Update()
    {
        transform.Translate(new Vector2(_directionX, 0).normalized * _speed * Time.deltaTime);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(gameObject.tag) == false)
            base.OnTriggerEnter2D(collision);
    }
}
