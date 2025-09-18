using System;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    private KeyCode _jump = KeyCode.Space;
    private KeyCode _shoot = KeyCode.Mouse0;

    public event Action JumpKeyPressed;
    public event Action ShootKeyPressed;

    public float HorizontalRaw { get; private set; }

    private void Update()
    {
        HorizontalRaw = Input.GetAxisRaw(Horizontal);

        if (Input.GetKeyDown(_jump))
        {
            JumpKeyPressed?.Invoke();
        }

        if (Input.GetKeyDown(_shoot))
            ShootKeyPressed?.Invoke();
    }
}
