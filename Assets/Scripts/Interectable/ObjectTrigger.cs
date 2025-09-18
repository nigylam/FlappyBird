using System;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour
{
    public event Action<IInteractable> Triggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IInteractable obj))
        {
            Triggered?.Invoke(obj);
        }
    }
}
