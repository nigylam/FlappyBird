using System;
using UnityEngine;

public class StartScreen : Window
{
    public event Action PlayButtonClicked;

    protected override void OnButtonClick()
    {
        PlayButtonClicked?.Invoke();
    }
}
