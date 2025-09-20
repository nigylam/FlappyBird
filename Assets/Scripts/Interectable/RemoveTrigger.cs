using System;
using UnityEngine;

public class RemoveTrigger : MonoBehaviour
{
    public event Action<Damager> Triggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Damager obj))
            Triggered?.Invoke(obj);
    }
}
