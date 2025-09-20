using System;
using UnityEngine;

public class Damager : MonoBehaviour, IDamaging
{
    private const string RemoveTriggerTagName = "RemoveTrigger";

    public Action<Damager> Collided;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(RemoveTriggerTagName) == false)
        {
            Collided?.Invoke(this);
        }
    }
}
