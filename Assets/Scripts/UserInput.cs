using System;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public event Action JumpKeyPressed;
    public event Action ShootKeyPressed;

    private KeyCode _jump = KeyCode.Space;
    private KeyCode _shoot = KeyCode.Mouse0;
    private bool _isFreezed = true;

    private void Update()
    {
        if (_isFreezed)
            return;

        if (Input.GetKeyDown(_jump))
            JumpKeyPressed?.Invoke();

        if (Input.GetKeyDown(_shoot))
            ShootKeyPressed?.Invoke();
    }

    public void Reset()
    {
        _isFreezed = false;
    }

    public void Freeze()
    {
        _isFreezed = true;
    }
}
