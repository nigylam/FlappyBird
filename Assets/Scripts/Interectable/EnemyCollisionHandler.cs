using System;
using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour
{
    public event Action<IInteractable> CollisionDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IInteractable interactable))
            CollisionDetected?.Invoke(interactable);
    }
}
