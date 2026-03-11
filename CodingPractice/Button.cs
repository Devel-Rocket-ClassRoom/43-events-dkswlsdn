using System;
using System.Collections.Generic;
using System.Text;

public class Button
{
    public event EventHandler Click;

    public void OnClick()
    {
        Click?.Invoke();
    }

    public delegate void EventHandler();
}